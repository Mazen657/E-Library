using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace library_app
{
    public partial class BooksForm : Form
    {
        #region Fields

        private string _currentCategory;

        #endregion

        #region Properties

        public string CurrentCategory
        {
            get => _currentCategory;
            set => _currentCategory = value;
        }

        public CardBook.DeleteMode CurrentDeleteMode { get; set; } = CardBook.DeleteMode.RemoveCategory;

        #endregion

        #region Events

        public event Action<Book> OnBookClicked;

        #endregion

        #region Constructor

        public BooksForm(string category)
        {
            InitializeComponent();

            _currentCategory = category;

            AddLogo.Cursor = Cursors.Hand;
            AddLogo.Click += AddLogo_Click;

            LoadBooks();
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match BooksForm.Designer.cs exactly — do not rename them.

        private void AddLogo_Click(object sender, EventArgs e)
        {
            OpenEditCategoryDialog();
        }

        #endregion

        #region Category Editing

        private void OpenEditCategoryDialog()
        {
            var editForm = new EditCategory(_currentCategory)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                // Category was renamed — update and reload
                _currentCategory = editForm.UpdatedCategoryName;
                this.Text = _currentCategory;
                LoadBooks();
            }
            else if (result == DialogResult.OK)
            {
                // Books were saved without renaming — reload only
                LoadBooks();
            }
        }

        #endregion

        #region Book Loading

        private void LoadBooks()
        {
            fLPBook.Controls.Clear();

            fLPBook.Controls.Add(BuildAddBookCard());

            List<Book> books = DatabaseHelper.GetBooksByCategory(_currentCategory);

            foreach (var book in books)
            {
                var card = CreateBookCard(book);
                fLPBook.Controls.Add(card);
            }
        }

        private CardBook CreateBookCard(Book book)
        {
            var card = new CardBook
            {
                Margin = new Padding(10),
                CurrentDeleteMode = CardBook.DeleteMode.RemoveCategory
            };

            card.SetData(book);
            card.OnBookClicked += OnCardBookClicked;
            card.OnDeleteRequested += OnCardDeleteRequested;

            return card;
        }

        #endregion

        #region Add Book Card Builder

        /// <summary>
        /// Builds the "Add Book" placeholder card shown at the start of the flow panel.
        /// </summary>
        private Panel BuildAddBookCard()
        {
            var addIcon = new PictureBox
            {
                Image = Properties.Resources.add,
                Size = new Size(51, 50),
                Location = new Point(64, 133),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };
            addIcon.Click += AddLogo_Click;

            var innerCard = new Panel
            {
                BackColor = SystemColors.Window,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(181, 325),
                Location = new Point(13, 19)
            };
            innerCard.Controls.Add(addIcon);

            var cardContainer = new Panel
            {
                Size = new Size(211, 356),
                Margin = new Padding(10)
            };
            cardContainer.Controls.Add(innerCard);

            return cardContainer;
        }

        #endregion

        #region Card Event Handlers

        private void OnCardBookClicked(Book book)
        {
            OnBookClicked?.Invoke(book);
        }

        private void OnCardDeleteRequested(object sender, Book book)
        {
            if (book == null) return;

            DatabaseHelper.RemoveCategoryFromBook(book.Id, _currentCategory);
            LoadBooks();
        }

        #endregion
    }
}