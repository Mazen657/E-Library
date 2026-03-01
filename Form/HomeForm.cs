using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace library_app
{
    internal class HomeForm : Form
    {
        #region Fields

        private Panel _topPanel;
        private Button _btnAddBook;
        private SearchBar _searchBar;
        private Label _lblBookCount;
        private Panel _emptyStatePanel;
        private Label _lblEmptyState;
        private FlowLayoutPanel _flowBooks;

        private const int CardWidth = 211;
        private const int CardHeight = 356;
        private const int CardMargin = 10;

        #endregion

        #region Events

        public event Action<Book> OnBookSelected;

        #endregion

        #region Constructor

        public HomeForm()
        {
            InitializeComponent();

            this.Load += OnFormLoad;
            _searchBar.OnSearch += OnSearch;
        }

        #endregion

        #region Form Load

        private void OnFormLoad(object sender, EventArgs e)
        {
            LoadBooks();
        }

        #endregion

        #region Book Loading

        private void LoadBooks()
        {
            var books = DatabaseHelper.GetAllBooks()
                .OrderByDescending(b => b.LastOpened)
                .ToList();

            RenderBookCards(books);
        }

        private void RenderBookCards(List<Book> books)
        {
            _flowBooks.Controls.Clear();

            _lblBookCount.Text = $"{books.Count} Books";
            UpdateEmptyState(books.Count > 0);

            foreach (var book in books)
            {
                var card = CreateBookCard(book);
                _flowBooks.Controls.Add(card);
            }
        }

        private CardBook CreateBookCard(Book book)
        {
            var card = new CardBook
            {
                CurrentDeleteMode = CardBook.DeleteMode.FullBook,
                Width = CardWidth,
                Height = CardHeight,
                Margin = new Padding(CardMargin)
            };

            card.SetData(book);

            card.OnBookClicked += (b) => OnBookSelected?.Invoke(b);
            card.OnDeleteRequested += (s, b) => ConfirmAndDeleteBook(b);
            card.OnBookOpened += (s, e) => LoadBooks();

            return card;
        }

        #endregion

        #region Search

        private void OnSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                LoadBooks();
                return;
            }

            var results = DatabaseHelper.GetAllBooks()
                .Where(b => MatchesQuery(b, query))
                .OrderByDescending(b => b.LastOpened)
                .ToList();

            RenderBookCards(results);
        }

        private bool MatchesQuery(Book book, string query)
        {
            bool titleMatch = book.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
            bool tagMatch = ParseCategoryTags(book.Category)
                                  .Any(tag => tag.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            return titleMatch || tagMatch;
        }

        private List<string> ParseCategoryTags(string categoryField)
        {
            if (string.IsNullOrWhiteSpace(categoryField))
                return new List<string>();

            return categoryField
                .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(tag => tag.Replace("_", " ").ToLower().Trim())
                .Distinct()
                .ToList();
        }

        #endregion

        #region Delete Book

        private void ConfirmAndDeleteBook(Book book)
        {
            if (book == null) return;

            bool deleteFile;
            bool confirmed = ShowDeleteConfirmationDialog(book, out deleteFile);

            if (!confirmed) return;

            DatabaseHelper.DeleteBookById(book.Id);

            if (deleteFile)
                TryDeleteBookFile(book);

            LoadBooks();
        }

        private bool ShowDeleteConfirmationDialog(Book book, out bool shouldDeleteFile)
        {
            shouldDeleteFile = false;

            using (var dialog = new Form())
            {
                dialog.Text = "Confirm Delete";
                dialog.Size = new Size(420, 210);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var lblMessage = new Label
                {
                    Text = $"Are you sure you want to delete:\n\"{book.Title}\"?",
                    Location = new Point(20, 20),
                    Size = new Size(370, 50),
                    Font = new Font("Segoe UI", 10F)
                };

                var chkDeleteFile = new CheckBox
                {
                    Text = "Also delete the book file from disk",
                    Location = new Point(20, 80),
                    Size = new Size(370, 25),
                    Font = new Font("Segoe UI", 9F)
                };

                var btnConfirm = new Button
                {
                    Text = "Delete",
                    DialogResult = DialogResult.Yes,
                    Location = new Point(220, 130),
                    Size = new Size(80, 30)
                };

                var btnCancel = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.No,
                    Location = new Point(315, 130),
                    Size = new Size(80, 30)
                };

                dialog.Controls.AddRange(new Control[] { lblMessage, chkDeleteFile, btnConfirm, btnCancel });
                dialog.AcceptButton = btnConfirm;
                dialog.CancelButton = btnCancel;

                var result = dialog.ShowDialog(this);
                shouldDeleteFile = chkDeleteFile.Checked;

                return result == DialogResult.Yes;
            }
        }

        private void TryDeleteBookFile(Book book)
        {
            if (!File.Exists(book.PdfPath)) return;

            try
            {
                File.Delete(book.PdfPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"The book was removed from the library, but the file could not be deleted:\n{ex.Message}",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        #endregion

        #region Empty State

        private void UpdateEmptyState(bool hasBooks)
        {
            _emptyStatePanel.Visible = !hasBooks;

            if (!hasBooks)
                CenterEmptyStatePanel();
        }

        private void CenterEmptyStatePanel()
        {
            int x = (ClientSize.Width - _emptyStatePanel.Width) / 2;
            int y = _topPanel.Height + (ClientSize.Height - _topPanel.Height - _emptyStatePanel.Height) / 2;

            _emptyStatePanel.Location = new Point(x, y);
            _emptyStatePanel.BringToFront();
        }

        #endregion

        #region Add Book

        private void OnAddBookClicked(object sender, EventArgs e)
        {
            var addBookForm = new AddBookForm();
            addBookForm.BookSaved += LoadBooks;
            addBookForm.ShowDialog();
        }

        #endregion

        #region Designer

        private void InitializeComponent()
        {
            _topPanel = new Panel();
            _lblBookCount = new Label();
            _flowBooks = new FlowLayoutPanel();
            _btnAddBook = new Button();
            _searchBar = new SearchBar();
            _emptyStatePanel = new Panel();
            _lblEmptyState = new Label();

            _topPanel.SuspendLayout();
            _flowBooks.SuspendLayout();
            _emptyStatePanel.SuspendLayout();
            SuspendLayout();

            // Top Panel
            _topPanel.Controls.Add(_btnAddBook);
            _topPanel.Controls.Add(_searchBar);
            _topPanel.Dock = DockStyle.Top;
            _topPanel.Size = new Size(840, 133);
            _topPanel.Name = "topPanel";

            // Book Count Label
            _lblBookCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _lblBookCount.AutoSize = true;
            _lblBookCount.Font = new Font("Microsoft Sans Serif", 14.25F);
            _lblBookCount.Location = new Point(719, 91);
            _lblBookCount.Margin = new Padding(0);
            _lblBookCount.Text = "0 Books";
            _lblBookCount.TextAlign = ContentAlignment.MiddleRight;
            _lblBookCount.Name = "lblBookCount";

            // Flow Panel
            _flowBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _flowBooks.AutoScroll = true;
            _flowBooks.Location = new Point(0, 131);
            _flowBooks.Size = new Size(840, 332);
            _flowBooks.Name = "flowBooks";

            // Add Book Button
            _btnAddBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            _btnAddBook.BackColor = Color.FromArgb(31, 32, 71);
            _btnAddBook.Cursor = Cursors.Hand;
            _btnAddBook.FlatAppearance.BorderSize = 0;
            _btnAddBook.FlatStyle = FlatStyle.Flat;
            _btnAddBook.ForeColor = Color.White;
            _btnAddBook.Image = Properties.Resources.addBook;
            _btnAddBook.ImageAlign = ContentAlignment.MiddleLeft;
            _btnAddBook.Location = new Point(695, 12);
            _btnAddBook.Padding = new Padding(12, 0, 0, 0);
            _btnAddBook.Size = new Size(127, 41);
            _btnAddBook.Text = "   Add Book";
            _btnAddBook.TextAlign = ContentAlignment.MiddleLeft;
            _btnAddBook.TextImageRelation = TextImageRelation.ImageBeforeText;
            _btnAddBook.UseVisualStyleBackColor = false;
            _btnAddBook.Click += OnAddBookClicked;
            _btnAddBook.Name = "btnAddBook";

            // Search Bar
            _searchBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _searchBar.BackColor = Color.Transparent;
            _searchBar.Location = new Point(22, 12);
            _searchBar.Size = new Size(667, 118);
            _searchBar.Name = "searchBar";

            // Empty State Label
            _lblEmptyState.AutoSize = true;
            _lblEmptyState.ForeColor = Color.Gray;
            _lblEmptyState.Location = new Point(284, 14);
            _lblEmptyState.Text = "Your library is empty. Click 'Add Book' to get started.";
            _lblEmptyState.Name = "lblEmptyState";

            // Empty State Panel
            _emptyStatePanel.Controls.Add(_lblEmptyState);
            _emptyStatePanel.Anchor = AnchorStyles.None;
            _emptyStatePanel.Size = new Size(837, 40);
            _emptyStatePanel.Visible = false;
            _emptyStatePanel.Name = "emptyStatePanel";

            // Form
            ClientSize = new Size(840, 463);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HomeForm";

            Controls.Add(_lblBookCount);
            Controls.Add(_topPanel);
            Controls.Add(_flowBooks);
            Controls.Add(_emptyStatePanel);

            _emptyStatePanel.BringToFront();

            _topPanel.ResumeLayout(false);
            _flowBooks.ResumeLayout(false);
            _emptyStatePanel.ResumeLayout(false);
            _emptyStatePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}