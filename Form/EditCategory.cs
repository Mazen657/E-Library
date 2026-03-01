using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace library_app
{
    public partial class EditCategory : Form
    {
        #region Fields

        private readonly string _originalCategoryName;

        #endregion

        #region Properties

        public string UpdatedCategoryName { get; private set; }

        #endregion

        #region Nested Types

        /// <summary>
        /// Lightweight model used to populate the "Add Book" combo box.
        /// </summary>
        public class BookDisplayItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }

        #endregion

        #region Constructor

        public EditCategory(string categoryName)
        {
            InitializeComponent();

            _originalCategoryName = categoryName;
            txtNameCategory.Text = categoryName ?? string.Empty;

            closeButton1.Load += closeButton1_Load;

            PopulateBookDropdown();
        }

        #endregion

        #region Book Dropdown

        private void PopulateBookDropdown()
        {
            var allBooks = DatabaseHelper.GetAllBooks();
            var currentBooks = DatabaseHelper.GetBooksByCategory(_originalCategoryName);

            // Books not yet assigned to this category
            var availableBooks = allBooks
                .Where(b => !currentBooks.Any(cb => cb.Id == b.Id))
                .ToList();

            var dropdownItems = new List<BookDisplayItem>
            {
                new BookDisplayItem { Id = -1, Title = "None" }
            };

            foreach (var book in availableBooks)
                dropdownItems.Add(new BookDisplayItem { Id = book.Id, Title = book.Title });

            comboBoxAddBook.DataSource = dropdownItems;
            comboBoxAddBook.DisplayMember = "Title";
            comboBoxAddBook.ValueMember = "Id";
        }

        #endregion

        #region Save

        // Name must match the designer binding: btnSave.Click → BtnSave_Click
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newName = txtNameCategory.Text?.Trim();

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show(
                    "Please enter a category name.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            bool isRenamed = !string.Equals(_originalCategoryName, newName, StringComparison.OrdinalIgnoreCase);

            AssignSelectedBookToCategory(newName, isRenamed);

            if (isRenamed)
            {
                DatabaseHelper.RenameCategory(_originalCategoryName, newName);
                UpdatedCategoryName = newName;

                // DialogResult.Yes signals to the caller that the category was renamed
                DialogResult = DialogResult.Yes;
            }
            else
            {
                UpdatedCategoryName = _originalCategoryName;

                // DialogResult.OK signals a regular save with no rename
                DialogResult = DialogResult.OK;
            }

            Close();
        }

        /// <summary>
        /// Assigns the selected book from the dropdown to the appropriate category,
        /// accounting for whether the category is being renamed.
        /// </summary>
        private void AssignSelectedBookToCategory(string newName, bool isRenamed)
        {
            int selectedBookId = (int)comboBoxAddBook.SelectedValue;

            // -1 means the user selected "None"
            if (selectedBookId == -1) return;

            DatabaseHelper.AddCategoryToBook(selectedBookId, _originalCategoryName);

            if (isRenamed)
                DatabaseHelper.AddCategoryToBook(selectedBookId, newName);
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match EditCategory.Designer.cs exactly — do not rename them.

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void closeButton1_Load(object sender, EventArgs e)
        {
            closeButton1.CloseClicked += (s, ev) => Close();
        }

        #endregion
    }
}