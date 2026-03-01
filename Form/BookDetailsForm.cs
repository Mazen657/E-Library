using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace library_app
{
    public partial class BookDetailsForm : Form
    {
        #region Fields

        private Book _book;

        #endregion

        #region Events

        public event Action OnCloseRequested;

        #endregion

        #region Constructor

        public BookDetailsForm(Book book)
        {
            InitializeComponent();

            _book = book;

            InitializeCoverBox();
            PopulateFields();
            LoadBookCover(book.PdfPath);
        }

        #endregion

        #region Initialization

        private void InitializeCoverBox()
        {
            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.Cursor = Cursors.Hand;
        }

        #endregion

        #region Data Binding

        private void PopulateFields()
        {
            txtTitle.Text = _book.Title;
            txtAuthor.Text = _book.Author;
            txtCategory.Text = _book.Category;
            txtNotes.Text = _book.Notes;
            txtPdfPath.Text = _book.PdfPath;
            picCover.Image = _book.Cover;
        }

        private void CollectFieldsIntoBook()
        {
            _book.Title = txtTitle.Text.Trim();
            _book.Author = txtAuthor.Text.Trim();
            _book.Category = txtCategory.Text.Trim();
            _book.Notes = txtNotes.Text.Trim();
        }

        #endregion

        #region Cover Loading

        private void LoadBookCover(string pdfPath)
        {
            try
            {
                if (!File.Exists(pdfPath))
                {
                    picCover.Image = null;
                    return;
                }

                string coverPath = PdfCoverHelper.GenerateCover(pdfPath);

                if (!File.Exists(coverPath)) return;

                using (var stream = new FileStream(coverPath, FileMode.Open, FileAccess.Read))
                {
                    picCover.Image = Image.FromStream(stream);
                }
            }
            catch
            {
                picCover.Image = null;
            }
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match BookDetailsForm.Designer.cs exactly — do not rename them.

        private void btnSave_Click(object sender, EventArgs e)
        {
            CollectFieldsIntoBook();
            DatabaseHelper.UpdateBook(_book);

            MessageBox.Show(
                "Changes saved successfully.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseRequested?.Invoke();
        }

        private void btnEditTitle_Click(object sender, EventArgs e) => EnableField(txtTitle);
        private void btnEditAuthor_Click(object sender, EventArgs e) => EnableField(txtAuthor);
        private void btnEditCategory_Click(object sender, EventArgs e) => EnableField(txtCategory);
        private void btnEditNotes_Click(object sender, EventArgs e) => EnableField(txtNotes);

        #endregion

        #region Field Editing

        /// <summary>
        /// Makes a read-only field editable when the user clicks its edit button.
        /// </summary>
        private void EnableField(TextBox field)
        {
            field.ReadOnly = false;
            field.Enabled = true;
            field.Focus();
        }

        #endregion
    }
}