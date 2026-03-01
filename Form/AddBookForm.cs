using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace library_app
{
    public partial class AddBookForm : Form
    {
        #region Constants

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        #endregion

        #region Fields

        private string _selectedPdfPath = string.Empty;

        #endregion

        #region Events

        public event Action BookSaved;

        #endregion

        #region Win32 Imports

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        #endregion

        #region Constructor

        public AddBookForm()
        {
            InitializeComponent();

            panelDropPdf.DragEnter += panelDropPdf_DragEnter;
            panelDropPdf.DragDrop += panelDropPdf_DragDrop;
            button2.Click += button2_Click;
            btnSave.Click += btnSave_Click;
            closeButton1.Load += closeButton1_Load;
        }

        #endregion

        #region Designer-Bound Handlers

        private void panelDropPdf_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void panelDropPdf_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files == null || files.Length == 0) return;
            LoadPdfFile(files[0]);
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                Title = "Select a PDF Book"
            })
            {
                // ── Restore default folder from settings ──────────────────────
                string savedFolder = SettingsManager.Get(SettingsManager.KeyDefaultBookFolder);
                if (!string.IsNullOrEmpty(savedFolder) && Directory.Exists(savedFolder))
                    dialog.InitialDirectory = savedFolder;
                // ─────────────────────────────────────────────────────────────

                if (dialog.ShowDialog() == DialogResult.OK)
                    LoadPdfFile(dialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            DatabaseHelper.InsertBook(BuildBookFromInputs());
            BookSaved?.Invoke();

            MessageBox.Show(
                "Book added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            Close();
        }

        private void button2_Click(object sender, EventArgs e) => Close();

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void closeButton1_Load(object sender, EventArgs e)
        {
            closeButton1.CloseClicked += (s, ev) => Close();
        }

        #endregion

        #region PDF Loading

        private void LoadPdfFile(string filePath)
        {
            if (!IsValidPdfFile(filePath)) return;

            _selectedPdfPath = filePath;
            txtPdfPath.Text = filePath;

            AutoFillTitleFromFileName(filePath);
            LoadBookCover(filePath);
        }

        private bool IsValidPdfFile(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".pdf") return true;

            MessageBox.Show(
                "Only PDF files are supported. Please select a valid PDF.",
                "Invalid File",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return false;
        }

        private void AutoFillTitleFromFileName(string filePath)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
                txtTitle.Text = Path.GetFileNameWithoutExtension(filePath);
        }

        private void LoadBookCover(string pdfPath)
        {
            string coverPath = PdfCoverHelper.GenerateCover(pdfPath);
            if (!File.Exists(coverPath)) return;

            pictureBoxCover.Image?.Dispose();
            pictureBoxCover.Image = Image.FromFile(coverPath);
            pictureBoxCover.Visible = true;
        }

        #endregion

        #region Validation & Save Helpers

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ShowValidationError("Please enter a title for the book.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(_selectedPdfPath))
            {
                ShowValidationError("Please select or drop a PDF file.");
                return false;
            }

            if (DatabaseHelper.BookExists(_selectedPdfPath))
            {
                MessageBox.Show(
                    "This book is already in your library.",
                    "Duplicate Book",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return false;
            }

            return true;
        }

        private Book BuildBookFromInputs()
        {
            return new Book
            {
                Title = txtTitle.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Category = cmbCategory.Text.Trim(),
                Notes = txtNotes.Text.Trim(),
                PdfPath = _selectedPdfPath
            };
        }

        private void ShowValidationError(string message)
        {
            MessageBox.Show(
                message,
                "Validation Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        #endregion
    }
}