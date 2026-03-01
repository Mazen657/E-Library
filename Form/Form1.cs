using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace library_app
{
    public partial class Form1 : Form
    {
        #region Constants

        private const int WM_NCHITTEST = 0x0084;
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int ResizeBorder = 2;

        #endregion

        #region Fields

        private Button _activeMenuButton;
        private Form _currentForm;
        private Rectangle _normalBounds;
        private bool _isMaximized;

        private readonly Random _random = new Random();
        private readonly Stack<Form> _navigationHistory = new Stack<Form>();

        #endregion

        #region Win32 Imports

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
            InitializeBackButton();
            DatabaseHelper.CreateCategoriesTable();

            this.Load += OnFormLoad;
            this.SizeChanged += OnSizeChanged;
        }

        #endregion

        #region Initialization

        private void InitializeBackButton()
        {
            picBack.Visible = false;
            picBack.Cursor = Cursors.Hand;
            picBack.Click += (s, e) => GoBack();
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            ActivateMenuButton(btnHome);
            LoadForm(new HomeForm());

            // ── Auto-open last book if the user enabled that setting ──────────
            if (SettingsManager.GetBool(SettingsManager.KeyAutoOpenLastBook))
                TryAutoOpenLastBook();
            // ─────────────────────────────────────────────────────────────────
        }

        /// <summary>
        /// Navigates straight to BookDetailsForm for the most-recently-opened book.
        /// Silently does nothing when the library is empty.
        /// </summary>
        private void TryAutoOpenLastBook()
        {
            var books = DatabaseHelper.GetAllBooks();
            if (books.Count == 0) return;

            // Find the book with the most recent LastOpened that isn't DateTime.MinValue
            Book lastBook = null;
            foreach (var b in books)
            {
                if (b.LastOpened == DateTime.MinValue) continue;
                if (lastBook == null || b.LastOpened > lastBook.LastOpened)
                    lastBook = b;
            }

            if (lastBook == null) return;

            ShowBookDetails(lastBook);
        }

        #endregion

        #region Navigation

        public void LoadForm(Form form, bool addToHistory = true)
        {
            if (addToHistory && _currentForm != null)
                _navigationHistory.Push(_currentForm);

            panelMain.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();

            _currentForm = form;

            BindFormEvents(form);
            RefreshBackButton();
        }

        private void GoBack()
        {
            if (_navigationHistory.Count == 0) return;

            Form previousForm = _navigationHistory.Pop();
            LoadForm(previousForm, addToHistory: false);
        }

        private void NavigateToCleanForm(Form form)
        {
            _navigationHistory.Clear();
            _currentForm = null;
            LoadForm(form);
        }

        #endregion

        #region Form Event Binding

        /// <summary>
        /// Binds events specific to each form type after loading.
        /// Always unsubscribes before subscribing to prevent duplicate handlers
        /// when a form is re-visited via GoBack.
        /// </summary>
        private void BindFormEvents(Form form)
        {
            switch (form)
            {
                case HomeForm home:
                    home.OnBookSelected -= ShowBookDetails;
                    home.OnBookSelected += ShowBookDetails;
                    break;

                case CategoriesForm categories:
                    categories.OnCategorySelected -= OpenBooksByCategory;
                    categories.OnCategorySelected += OpenBooksByCategory;
                    break;

                case BooksForm books:
                    books.OnBookClicked -= ShowBookDetails;
                    books.OnBookClicked += ShowBookDetails;
                    break;
            }
        }

        private void ShowBookDetails(Book book)
        {
            if (book == null) return;

            var detailsForm = new BookDetailsForm(book);
            detailsForm.OnCloseRequested += GoBack;

            LoadForm(detailsForm);
        }

        private void OpenBooksByCategory(string category)
        {
            var booksForm = new BooksForm(category)
            {
                CurrentDeleteMode = CardBook.DeleteMode.RemoveCategory
            };

            LoadForm(booksForm);
        }

        #endregion

        #region Back Button

        private void RefreshBackButton()
        {
            bool shouldShow = (_currentForm is BookDetailsForm || _currentForm is BooksForm)
                              && _navigationHistory.Count > 0;

            picBack.Visible = shouldShow;
        }

        #endregion

        #region Menu Button Theming

        private void ActivateMenuButton(Button button)
        {
            if (button == null || button == _activeMenuButton) return;

            ResetAllMenuButtons();

            _activeMenuButton = button;
            _activeMenuButton.BackColor = PickAccentColor();
            _activeMenuButton.ForeColor = Color.White;
            _activeMenuButton.Font = CreateMenuFont(12.5F);
        }

        private void ResetAllMenuButtons()
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (!(control is Button btn)) continue;

                btn.BackColor = Color.FromArgb(31, 32, 71);
                btn.ForeColor = Color.Gainsboro;
                btn.Font = CreateMenuFont(10F);
            }
        }

        private Font CreateMenuFont(float size)
        {
            return new Font("Microsoft Sans Serif", size,
                FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        /// <summary>
        /// Returns the accent color. Uses the saved setting when one exists;
        /// otherwise falls back to a random color from the theme list.
        /// </summary>
        private Color PickAccentColor()
        {
            int savedIndex = SettingsManager.GetInt(SettingsManager.KeyAccentColorIndex, -1);

            if (savedIndex >= 0 && savedIndex < ThemeColor.ColorList.Count)
                return ColorTranslator.FromHtml(ThemeColor.ColorList[savedIndex]);

            // No saved preference — pick randomly, avoiding the last used index
            int lastIndex = -1;
            int index;
            do { index = _random.Next(ThemeColor.ColorList.Count); }
            while (index == lastIndex && ThemeColor.ColorList.Count > 1);

            lastIndex = index;
            return ColorTranslator.FromHtml(ThemeColor.ColorList[index]);
        }

        #endregion

        #region Window Maximize / Restore

        private void ToggleMaximize()
        {
            if (!_isMaximized)
            {
                _normalBounds = this.Bounds;
                this.Bounds = Screen.FromHandle(this.Handle).WorkingArea;
                _isMaximized = true;
                controlWindow1.SetMinimizeIcon();
            }
            else
            {
                this.Bounds = _normalBounds;
                _isMaximized = false;
                controlWindow1.SetMaximizeIcon();
            }
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (_isMaximized) controlWindow1.SetMinimizeIcon();
            else controlWindow1.SetMaximizeIcon();
        }

        #endregion

        #region Borderless Window Drag & Resize

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST && !_isMaximized)
            {
                Point client = PointToClient(new Point(
                    m.LParam.ToInt32() & 0xFFFF,
                    (m.LParam.ToInt32() >> 16) & 0xFFFF));

                IntPtr hit = GetResizeHitTest(client);
                if (hit != IntPtr.Zero)
                {
                    m.Result = hit;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private IntPtr GetResizeHitTest(Point p)
        {
            int x = p.X, y = p.Y;
            int w = ClientSize.Width, h = ClientSize.Height;
            int b = ResizeBorder;

            if (x <= b && y <= b) return (IntPtr)HTTOPLEFT;
            if (x >= w - b && y <= b) return (IntPtr)HTTOPRIGHT;
            if (x <= b && y >= h - b) return (IntPtr)HTBOTTOMLEFT;
            if (x >= w - b && y >= h - b) return (IntPtr)HTBOTTOMRIGHT;
            if (x <= b) return (IntPtr)HTLEFT;
            if (x >= w - b) return (IntPtr)HTRIGHT;
            if (y <= b) return (IntPtr)HTTOP;
            if (y >= h - b) return (IntPtr)HTBOTTOM;

            return IntPtr.Zero;
        }

        #endregion

        #region Button Click Handlers

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateMenuButton((Button)sender);
            NavigateToCleanForm(new HomeForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ActivateMenuButton((Button)sender);
            NavigateToCleanForm(new CategoriesForm());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateMenuButton((Button)sender);
            NavigateToCleanForm(new SettingForm());
        }

        #endregion

        #region Control Window Events

        private void controlWindow1_Load(object sender, EventArgs e)
        {
            controlWindow1.CloseClicked += (s, ev) => this.Close();
            controlWindow1.MinimizeClicked += (s, ev) => this.WindowState = FormWindowState.Minimized;
            controlWindow1.MaximizeClicked += (s, ev) => ToggleMaximize();
        }

        #endregion

        #region Designer-Required Stubs

        private void ColorPanel(object sender, EventArgs e)
        {
            this.BackColor = panelMenu.BackColor;
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e) { }

        private void picBack_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        #endregion
    }
}