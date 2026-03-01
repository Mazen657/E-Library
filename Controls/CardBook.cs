using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace library_app
{
    public partial class CardBook : UserControl
    {
        #region Enums

        public enum DeleteMode
        {
            FullBook,       // Removes the book entirely from the library
            RemoveCategory  // Removes only the associated category from the book
        }

        #endregion

        #region Properties

        public Book CurrentBook { get; private set; }
        public DeleteMode CurrentDeleteMode { get; set; } = DeleteMode.FullBook;

        #endregion

        #region Events

        public event EventHandler<Book> OnDeleteRequested;
        public event EventHandler OnBookOpened;
        public event Action<Book> OnBookClicked;

        #endregion

        #region Constructor

        public CardBook()
        {
            InitializeComponent();

            picCover.SizeMode = PictureBoxSizeMode.Zoom;
            picCover.Cursor = Cursors.Hand;
            lblTitle.Cursor = Cursors.Hand;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Populates the card with the given book's data and loads its cover image.
        /// </summary>
        public void SetData(Book book)
        {
            if (book == null) return;

            CurrentBook = book;
            lblTitle.Text = book.Title;

            LoadCover(book.PdfPath);
        }

        #endregion

        #region Cover Loading

        private void LoadCover(string pdfPath)
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

        #region Open Book

        private void OpenBook()
        {
            if (!File.Exists(CurrentBook?.PdfPath))
            {
                MessageBox.Show(
                    "The PDF file could not be found.",
                    "File Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = CurrentBook.PdfPath,
                UseShellExecute = true
            });

            CurrentBook.LastOpened = DateTime.Now;
            DatabaseHelper.UpdateBookLastOpened(CurrentBook.Id, CurrentBook.LastOpened);
            OnBookOpened?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match CardBook.Designer.cs exactly — do not rename them.

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenBook();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CurrentBook == null) return;
            OnDeleteRequested?.Invoke(this, CurrentBook);
        }

        private void pictureBoxCover_Click(object sender, EventArgs e)
        {
            if (CurrentBook != null)
                OnBookClicked?.Invoke(CurrentBook);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            if (CurrentBook != null)
                OnBookClicked?.Invoke(CurrentBook);
        }

        #endregion
    }
}