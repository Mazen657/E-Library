using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace library_app
{
    internal class CategoriesForm : Form
    {
        #region Fields

        private Panel _addFolderPanel;
        private Label _lblAddFolder;
        private PictureBox _picAddFolder;
        private FlowLayoutPanel _flowCategories;
        private ContextMenuStrip _contextMenu;

        private string _rightClickedCategory;

        #endregion

        #region Events

        public event Action<string> OnCategorySelected;

        #endregion

        #region Constructor

        public CategoriesForm()
        {
            InitializeComponent();
            BuildContextMenu();
            BindAddFolderControls();
            LoadCategories();
        }

        #endregion

        #region Initialization

        private void BindAddFolderControls()
        {
            _picAddFolder.Cursor = Cursors.Hand;
            _picAddFolder.Click += PicAddFolder_Click;

            _lblAddFolder.Cursor = Cursors.Hand;
            _lblAddFolder.Click += PicAddFolder_Click;
        }

        private void BuildContextMenu()
        {
            _contextMenu = new ContextMenuStrip();

            var openItem = new ToolStripMenuItem("Open");
            openItem.Click += (s, e) => OpenCategory(_rightClickedCategory);

            var renameItem = new ToolStripMenuItem("Rename");
            renameItem.Click += OnRenameClicked;

            var deleteItem = new ToolStripMenuItem("Delete");
            deleteItem.Click += OnDeleteClicked;

            var separator = new ToolStripSeparator();

            var propertiesItem = new ToolStripMenuItem("Properties");
            propertiesItem.Click += OnPropertiesClicked;

            _contextMenu.Items.AddRange(new ToolStripItem[]
            {
                openItem,
                renameItem,
                deleteItem,
                separator,
                propertiesItem
            });
        }

        #endregion

        #region Category Loading

        private void LoadCategories()
        {
            _flowCategories.Controls.Clear();
            _flowCategories.Controls.Add(_addFolderPanel);

            var allCategories = GetMergedCategories();

            foreach (var category in allCategories)
            {
                var folder = CreateFolderControl(category);
                _flowCategories.Controls.Add(folder);
            }
        }

        private List<string> GetMergedCategories()
        {
            var fromTable = DatabaseHelper.GetAllCategories();
            var fromBooks = GetUniqueCategoriesFromBooks();

            return fromTable
                .Union(fromBooks, StringComparer.OrdinalIgnoreCase)
                .OrderBy(c => c)
                .ToList();
        }

        private List<string> GetUniqueCategoriesFromBooks()
        {
            return DatabaseHelper.GetAllBooks()
                .SelectMany(b => b.Category.Split(' '))
                .Select(tag => tag.Replace("#", "").Replace("_", " "))
                .Where(tag => !string.IsNullOrWhiteSpace(tag))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        #endregion

        #region Folder Control Builder

        /// <summary>
        /// Creates a folder control for a category and binds all its events.
        /// </summary>
        private Folders CreateFolderControl(string category)
        {
            var folder = new Folders();
            folder.SetCategoryName(category);
            folder.Tag = category;

            bool hasBooks = DatabaseHelper.GetBooksByCategory(category).Any();
            folder.SetFolderImage(hasBooks);

            folder.OnFolderClick += OnFolderClicked;
            folder.OnFolderRightClick += OnFolderRightClicked;
            folder.MouseUp += OnFolderMouseUp;

            // Propagate right-click from child controls up to the folder
            foreach (Control child in folder.Controls)
            {
                child.MouseUp += (s, e) =>
                {
                    if (e.Button == MouseButtons.Right)
                        ShowContextMenuForFolder(folder);
                };
            }

            return folder;
        }

        #endregion

        #region Folder Event Handlers

        private void OnFolderClicked(string categoryName)
        {
            OpenCategory(categoryName);
        }

        private void OnFolderRightClicked(string categoryName)
        {
            _rightClickedCategory = categoryName;
            _contextMenu.Show(Cursor.Position);
        }

        private void OnFolderMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (sender is Folders folder)
                ShowContextMenuForFolder(folder);
        }

        private void ShowContextMenuForFolder(Folders folder)
        {
            _rightClickedCategory = folder.Tag.ToString();
            _contextMenu.Show(Cursor.Position);
        }

        #endregion

        #region Open Category

        private void OpenCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) return;
            OnCategorySelected?.Invoke(categoryName);
        }

        #endregion

        #region Add Category

        private void PicAddFolder_Click(object sender, EventArgs e)
        {
            string defaultName = GenerateUniqueCategoryName();
            DatabaseHelper.AddCategory(defaultName);

            var editForm = new EditCategory(defaultName)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            DialogResult result = editForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
                // Category was renamed — update everywhere and open it
                string newName = editForm.UpdatedCategoryName;
                DatabaseHelper.RenameCategoryInTable(defaultName, newName);
                DatabaseHelper.RenameCategory(defaultName, newName);
                LoadCategories();
                OnCategorySelected?.Invoke(newName);
            }
            else if (result == DialogResult.OK)
            {
                // Saved without renaming — open with default name
                LoadCategories();
                OnCategorySelected?.Invoke(defaultName);
            }
            else
            {
                // Cancelled — discard the newly created category
                DatabaseHelper.DeleteCategory(defaultName);
                LoadCategories();
            }
        }

        private string GenerateUniqueCategoryName()
        {
            var existing = DatabaseHelper.GetAllCategories()
                .Union(GetUniqueCategoriesFromBooks(), StringComparer.OrdinalIgnoreCase);

            const string baseName = "New Folder";

            if (!existing.Any(c => c.Equals(baseName, StringComparison.OrdinalIgnoreCase)))
                return baseName;

            int counter = 1;
            string candidate;
            do
            {
                candidate = $"{baseName} {counter}";
                counter++;
            }
            while (existing.Any(c => c.Equals(candidate, StringComparison.OrdinalIgnoreCase)));

            return candidate;
        }

        #endregion

        #region Context Menu Handlers

        private void OnRenameClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rightClickedCategory)) return;

            var editForm = new EditCategory(_rightClickedCategory)
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            if (editForm.ShowDialog() != DialogResult.Yes) return;

            string newName = editForm.UpdatedCategoryName;
            DatabaseHelper.RenameCategoryInTable(_rightClickedCategory, newName);
            DatabaseHelper.RenameCategory(_rightClickedCategory, newName);

            LoadCategories();
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rightClickedCategory)) return;

            var confirmed = MessageBox.Show(
                $"Are you sure you want to delete \"{_rightClickedCategory}\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirmed != DialogResult.Yes) return;

            DatabaseHelper.DeleteCategory(_rightClickedCategory);

            foreach (var book in DatabaseHelper.GetBooksByCategory(_rightClickedCategory))
                DatabaseHelper.RemoveCategoryFromBook(book.Id, _rightClickedCategory);

            LoadCategories();
        }

        private void OnPropertiesClicked(object sender, EventArgs e)
        {
            int count = DatabaseHelper.GetBooksByCategory(_rightClickedCategory).Count();
            string unit = count == 1 ? "Book" : "Books";
            string message = $"Category: {_rightClickedCategory}\n\nBook Count: {count} {unit}";

            MessageBox.Show(message, "Category Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Designer

        private void InitializeComponent()
        {
            _flowCategories = new System.Windows.Forms.FlowLayoutPanel();
            _addFolderPanel = new System.Windows.Forms.Panel();
            _lblAddFolder = new System.Windows.Forms.Label();
            _picAddFolder = new System.Windows.Forms.PictureBox();

            _flowCategories.SuspendLayout();
            _addFolderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(_picAddFolder)).BeginInit();
            SuspendLayout();

            // Flow Panel
            _flowCategories.AutoScroll = true;
            _flowCategories.Controls.Add(_addFolderPanel);
            _flowCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            _flowCategories.Location = new System.Drawing.Point(0, 0);
            _flowCategories.Name = "flowCategories";
            _flowCategories.Size = new System.Drawing.Size(824, 424);
            _flowCategories.TabIndex = 0;

            // Add Folder Panel
            _addFolderPanel.Controls.Add(_lblAddFolder);
            _addFolderPanel.Controls.Add(_picAddFolder);
            _addFolderPanel.Location = new System.Drawing.Point(3, 3);
            _addFolderPanel.Name = "addFolderPanel";
            _addFolderPanel.Size = new System.Drawing.Size(170, 198);
            _addFolderPanel.TabIndex = 0;

            // Add Folder Label
            _lblAddFolder.AutoSize = true;
            _lblAddFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            _lblAddFolder.Location = new System.Drawing.Point(22, 162);
            _lblAddFolder.Name = "lblAddFolder";
            _lblAddFolder.Size = new System.Drawing.Size(125, 24);
            _lblAddFolder.TabIndex = 1;
            _lblAddFolder.Text = "Add Category";

            // Add Folder Icon
            _picAddFolder.Image = Properties.Resources.add_folder;
            _picAddFolder.Location = new System.Drawing.Point(9, 9);
            _picAddFolder.Name = "picAddFolder";
            _picAddFolder.Size = new System.Drawing.Size(150, 150);
            _picAddFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            _picAddFolder.TabIndex = 0;
            _picAddFolder.TabStop = false;

            // Form
            ClientSize = new System.Drawing.Size(824, 424);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "CategoriesForm";

            Controls.Add(_flowCategories);

            _flowCategories.ResumeLayout(false);
            _addFolderPanel.ResumeLayout(false);
            _addFolderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(_picAddFolder)).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}