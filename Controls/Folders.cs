using System;
using System.Windows.Forms;

namespace library_app
{
    public partial class Folders : UserControl
    {
        #region Fields

        private string _categoryName;

        #endregion

        #region Events

        public event Action<string> OnFolderClick;
        public event Action<string> OnFolderRightClick;

        #endregion

        #region Constructor

        public Folders()
        {
            InitializeComponent();

            // Click events use EventHandler (object, EventArgs)
            this.Click += OnClick;
            pictureBox1.Click += OnClick;
            lblNameCategory.Click += OnClick;

            // MouseDown events use MouseEventHandler (object, MouseEventArgs)
            this.MouseDown += OnMouseDown;
            pictureBox1.MouseDown += OnMouseDown;
            lblNameCategory.MouseDown += OnMouseDown;
        }

        #endregion

        #region Public API

        /// <summary>
        /// Sets the display name of the category shown on the folder label.
        /// </summary>
        public void SetCategoryName(string name)
        {
            _categoryName = name;
            lblNameCategory.Text = name;
        }

        /// <summary>
        /// Returns the category name currently assigned to this folder.
        /// </summary>
        public string GetCategoryName() => _categoryName;

        /// <summary>
        /// Updates the folder icon to reflect whether it contains books.
        /// </summary>
        public void SetFolderImage(bool hasBooks)
        {
            pictureBox1.Image = hasBooks
                ? Properties.Resources.books_folder
                : Properties.Resources.emty_folder;
        }

        #endregion

        #region Mouse Handlers

        // Handles standard Click events — signature must be (object, EventArgs)
        private void OnClick(object sender, EventArgs e)
        {
            OnFolderClick?.Invoke(_categoryName);
        }

        // Handles MouseDown events — distinguishes left from right click
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                OnFolderRightClick?.Invoke(_categoryName);
            else if (e.Button == MouseButtons.Left)
                OnFolderClick?.Invoke(_categoryName);
        }

        #endregion
    }
}