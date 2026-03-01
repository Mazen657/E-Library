using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace library_app
{
    internal class SettingForm : Form
    {
        #region Fields

        // Layout panels
        private Panel _panelSidebar;
        private Panel _panelContent;

        // Sidebar nav buttons
        private Button _btnAppearance;
        private Button _btnLibrary;
        private Button _btnData;
        private Button _btnAbout;
        private Button _activeSideBtn;

        // Content sub-panels
        private Panel _pageAppearance;
        private Panel _pageLibrary;
        private Panel _pageData;
        private Panel _pageAbout;

        // Appearance controls
        private FlowLayoutPanel _flowColors;

        // Library controls
        private TextBox _txtDefaultFolder;
        private Button _btnBrowseFolder;
        private CheckBox _chkAutoOpenLast;

        #endregion

        #region Constructor

        public SettingForm()
        {
            InitializeLayout();
            BuildSidebar();
            BuildPageAppearance();
            BuildPageLibrary();
            BuildPageData();
            BuildPageAbout();
            LoadCurrentSettings();
            ShowPage(_pageAppearance, _btnAppearance);
        }

        #endregion

        #region Layout Init

        private void InitializeLayout()
        {
            this.ClientSize = new Size(824, 463);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "SettingForm";
            this.BackColor = Color.White;

            // Sidebar
            _panelSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 200,
                BackColor = Color.FromArgb(31, 32, 71)
            };

            // Content area
            _panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 246, 250),
                Padding = new Padding(30)
            };

            this.Controls.Add(_panelContent);
            this.Controls.Add(_panelSidebar);
        }

        #endregion

        #region Sidebar

        private void BuildSidebar()
        {
            // Header label
            var lblSettings = new Label
            {
                Text = "Settings",
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold),
                Location = new Point(16, 24),
                Size = new Size(170, 30),
                AutoSize = false
            };

            // Separator line
            var sep = new Panel
            {
                BackColor = Color.FromArgb(60, 62, 110),
                Location = new Point(0, 64),
                Size = new Size(200, 1)
            };

            _panelSidebar.Controls.Add(lblSettings);
            _panelSidebar.Controls.Add(sep);

            _btnAppearance = CreateSidebarButton("🎨  Appearance", 80);
            _btnLibrary = CreateSidebarButton("📁  Library", 140);
            _btnData = CreateSidebarButton("🗄️  Data", 200);
            _btnAbout = CreateSidebarButton("ℹ️  About", 260);

            _btnAppearance.Click += (s, e) => ShowPage(_pageAppearance, _btnAppearance);
            _btnLibrary.Click += (s, e) => ShowPage(_pageLibrary, _btnLibrary);
            _btnData.Click += (s, e) => ShowPage(_pageData, _btnData);
            _btnAbout.Click += (s, e) => ShowPage(_pageAbout, _btnAbout);

            _panelSidebar.Controls.AddRange(new Control[]
            {
                _btnAppearance, _btnLibrary, _btnData, _btnAbout
            });
        }

        private Button CreateSidebarButton(string text, int top)
        {
            return new Button
            {
                Text = text,
                Location = new Point(0, top),
                Size = new Size(200, 48),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(200, 200, 230),
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 10F),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 },
                UseVisualStyleBackColor = false
            };
        }

        private void ShowPage(Panel page, Button sideBtn)
        {
            // Hide all pages
            foreach (var p in new[] { _pageAppearance, _pageLibrary, _pageData, _pageAbout })
            {
                if (p != null) p.Visible = false;
            }

            // Reset all sidebar buttons
            if (_activeSideBtn != null)
            {
                _activeSideBtn.BackColor = Color.Transparent;
                _activeSideBtn.ForeColor = Color.FromArgb(200, 200, 230);
                _activeSideBtn.Font = new Font("Microsoft Sans Serif", 10F);
            }

            // Activate selected
            page.Visible = true;
            _activeSideBtn = sideBtn;
            sideBtn.BackColor = Color.FromArgb(50, 52, 100);
            sideBtn.ForeColor = Color.White;
            sideBtn.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
        }

        #endregion

        #region Page: Appearance

        private void BuildPageAppearance()
        {
            _pageAppearance = CreateContentPage();

            AddPageTitle(_pageAppearance, "Appearance");
            AddSectionLabel(_pageAppearance, "Accent Color", 60);

            var desc = CreateDescLabel("Choose the accent color used for the active menu button.", 88);
            _pageAppearance.Controls.Add(desc);

            _flowColors = new FlowLayoutPanel
            {
                Location = new Point(0, 120),
                Size = new Size(740, 220),
                AutoScroll = false,
                WrapContents = true,
                BackColor = Color.Transparent
            };

            int savedIndex = SettingsManager.GetInt(SettingsManager.KeyAccentColorIndex, 0);

            for (int i = 0; i < ThemeColor.ColorList.Count; i++)
            {
                int idx = i; // capture
                Color c = ColorTranslator.FromHtml(ThemeColor.ColorList[i]);

                var swatch = new Panel
                {
                    Size = new Size(46, 46),
                    BackColor = c,
                    Margin = new Padding(6),
                    Cursor = Cursors.Hand,
                    Tag = idx
                };

                // Highlight saved selection
                if (idx == savedIndex)
                    DrawSelectedBorder(swatch);

                swatch.Click += (s, e) =>
                {
                    SettingsManager.Set(SettingsManager.KeyAccentColorIndex, idx);

                    // Update border on all swatches
                    foreach (Control ctrl in _flowColors.Controls)
                    {
                        ctrl.Invalidate();
                        ctrl.Paint -= OnSwatchPaint; // clear old
                    }
                    swatch.Invalidate();

                    // Re-draw borders
                    foreach (Control ctrl in _flowColors.Controls)
                    {
                        int ctrlIdx = (int)ctrl.Tag;
                        if (ctrlIdx == idx)
                            DrawSelectedBorder((Panel)ctrl);
                        else
                            ClearSelectedBorder((Panel)ctrl);
                    }

                    MessageBox.Show(
                        "Accent color saved. It will be applied next time you click a menu button.",
                        "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                _flowColors.Controls.Add(swatch);
            }

            _pageAppearance.Controls.Add(_flowColors);
            _panelContent.Controls.Add(_pageAppearance);
        }

        private void DrawSelectedBorder(Panel swatch)
        {
            swatch.Paint -= OnSwatchPaint;
            swatch.Paint += OnSwatchPaint;
        }

        private void ClearSelectedBorder(Panel swatch)
        {
            swatch.Paint -= OnSwatchPaint;
            swatch.Refresh();
        }

        private void OnSwatchPaint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            using (var pen = new Pen(Color.Black, 3))
                e.Graphics.DrawRectangle(pen, 1, 1, p.Width - 3, p.Height - 3);
        }

        #endregion

        #region Page: Library

        private void BuildPageLibrary()
        {
            _pageLibrary = CreateContentPage();

            AddPageTitle(_pageLibrary, "Library");

            // --- Default Folder ---
            AddSectionLabel(_pageLibrary, "Default Book Folder", 60);
            _pageLibrary.Controls.Add(CreateDescLabel(
                "When adding a new book, the file browser will open here by default.", 88));

            _txtDefaultFolder = new TextBox
            {
                Location = new Point(0, 120),
                Size = new Size(550, 30),
                Font = new Font("Microsoft Sans Serif", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                BackColor = Color.White
            };

            _btnBrowseFolder = new Button
            {
                Text = "Browse…",
                Location = new Point(560, 120),
                Size = new Size(100, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(31, 32, 71),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };
            _btnBrowseFolder.Click += (s, e) =>
            {
                using (var dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select default folder for adding books";
                    if (!string.IsNullOrEmpty(_txtDefaultFolder.Text) && Directory.Exists(_txtDefaultFolder.Text))
                        dlg.SelectedPath = _txtDefaultFolder.Text;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        _txtDefaultFolder.Text = dlg.SelectedPath;
                        SettingsManager.Set(SettingsManager.KeyDefaultBookFolder, dlg.SelectedPath);
                        ShowSavedToast("Default folder saved.");
                    }
                }
            };

            var btnClearFolder = new Button
            {
                Text = "Clear",
                Location = new Point(668, 120),
                Size = new Size(72, 30),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };
            btnClearFolder.Click += (s, e) =>
            {
                _txtDefaultFolder.Text = string.Empty;
                SettingsManager.Set(SettingsManager.KeyDefaultBookFolder, string.Empty);
                ShowSavedToast("Default folder cleared.");
            };

            // --- Auto-open Last Book ---
            AddSectionLabel(_pageLibrary, "Startup Behavior", 175);
            _pageLibrary.Controls.Add(CreateDescLabel(
                "Automatically open the last-viewed book when the app starts.", 203));

            _chkAutoOpenLast = new CheckBox
            {
                Text = "Open last book on startup",
                Location = new Point(0, 230),
                Size = new Size(300, 28),
                Font = new Font("Microsoft Sans Serif", 10F),
                Cursor = Cursors.Hand
            };
            _chkAutoOpenLast.CheckedChanged += (s, e) =>
            {
                SettingsManager.Set(SettingsManager.KeyAutoOpenLastBook, _chkAutoOpenLast.Checked);
                ShowSavedToast(_chkAutoOpenLast.Checked ? "Auto-open enabled." : "Auto-open disabled.");
            };

            _pageLibrary.Controls.AddRange(new Control[]
            {
                _txtDefaultFolder, _btnBrowseFolder, btnClearFolder, _chkAutoOpenLast
            });

            _panelContent.Controls.Add(_pageLibrary);
        }

        #endregion

        #region Page: Data Management

        private void BuildPageData()
        {
            _pageData = CreateContentPage();

            AddPageTitle(_pageData, "Data Management");

            // --- Backup ---
            AddSectionLabel(_pageData, "Backup & Restore", 60);
            _pageData.Controls.Add(CreateDescLabel(
                "Save a copy of the library database or restore from a previous backup.", 88));

            var btnBackup = CreateActionButton("📤  Backup Database", 120,
                Color.FromArgb(31, 32, 71));
            btnBackup.Click += OnBackupClicked;

            var btnRestore = CreateActionButton("📥  Restore Database", 120,
                Color.FromArgb(40, 167, 69), offsetX: 200);
            btnRestore.Click += OnRestoreClicked;

            // --- Cache ---
            AddSectionLabel(_pageData, "Cover Cache", 190);
            _pageData.Controls.Add(CreateDescLabel(
                "Clears the cached PDF cover images (they will be regenerated on next open).", 218));

            var btnClearCache = CreateActionButton("🗑️  Clear Cover Cache", 250,
                Color.FromArgb(255, 153, 0));
            btnClearCache.Click += OnClearCacheClicked;

            // --- Reset ---
            AddSectionLabel(_pageData, "Reset", 310);
            _pageData.Controls.Add(CreateDescLabel(
                "Permanently delete all books, categories, and settings. This cannot be undone.", 338));

            var btnReset = CreateActionButton("⚠️  Reset All Data", 370,
                Color.FromArgb(220, 53, 69));
            btnReset.Click += OnResetAllClicked;

            _pageData.Controls.AddRange(new Control[]
            {
                btnBackup, btnRestore, btnClearCache, btnReset
            });

            _panelContent.Controls.Add(_pageData);
        }

        private Button CreateActionButton(string text, int top,
            Color backColor, int offsetX = 0)
        {
            return new Button
            {
                Text = text,
                Location = new Point(offsetX, top),
                Size = new Size(185, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = backColor,
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9.5F),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };
        }

        private void OnBackupClicked(object sender, EventArgs e)
        {
            string dbPath = DatabaseHelper.GetDatabasePath();
            if (!File.Exists(dbPath))
            {
                MessageBox.Show("Database file not found.", "Backup",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new SaveFileDialog
            {
                Title = "Save Backup",
                Filter = "Database Backup (*.db)|*.db",
                FileName = $"library_backup_{DateTime.Now:yyyyMMdd_HHmm}.db"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    File.Copy(dbPath, dlg.FileName, overwrite: true);
                    MessageBox.Show("Backup saved successfully.", "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Backup failed:\n{ex.Message}", "Backup",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnRestoreClicked(object sender, EventArgs e)
        {
            var warn = MessageBox.Show(
                "Restoring a backup will replace your current library data.\n\nContinue?",
                "Restore Database",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (warn != DialogResult.Yes) return;

            using (var dlg = new OpenFileDialog
            {
                Title = "Select Backup File",
                Filter = "Database Backup (*.db)|*.db"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string dbPath = DatabaseHelper.GetDatabasePath();
                    File.Copy(dlg.FileName, dbPath, overwrite: true);
                    MessageBox.Show(
                        "Database restored. Please restart the application for changes to take effect.",
                        "Restore Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Restore failed:\n{ex.Message}", "Restore",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OnClearCacheClicked(object sender, EventArgs e)
        {
            string cacheDir = PdfCoverHelper.GetCacheDirectory();

            if (!Directory.Exists(cacheDir))
            {
                MessageBox.Show("Cover cache is already empty.", "Clear Cache",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var files = Directory.GetFiles(cacheDir);

            if (files.Length == 0)
            {
                MessageBox.Show("Cover cache is already empty.", "Clear Cache",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Delete {files.Length} cached cover image(s)?",
                "Clear Cover Cache",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int deleted = 0;
            foreach (var file in files)
            {
                try { File.Delete(file); deleted++; }
                catch { /* skip locked files */ }
            }

            MessageBox.Show($"{deleted} cached image(s) deleted.", "Done",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnResetAllClicked(object sender, EventArgs e)
        {
            var first = MessageBox.Show(
                "This will permanently delete ALL books, categories, and settings.\n\nThis cannot be undone.",
                "Reset All Data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (first != DialogResult.Yes) return;

            var second = MessageBox.Show(
                "Are you absolutely sure? All your library data will be lost.",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (second != DialogResult.Yes) return;

            try
            {
                DatabaseHelper.ResetDatabase();
                SettingsManager.Set(SettingsManager.KeyDefaultBookFolder, string.Empty);
                SettingsManager.Set(SettingsManager.KeyAutoOpenLastBook, false);
                SettingsManager.Set(SettingsManager.KeyAccentColorIndex, 0);

                MessageBox.Show(
                    "All data has been reset. Please restart the application.",
                    "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Reset failed:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Page: About

        private void BuildPageAbout()
        {
            _pageAbout = CreateContentPage();

            AddPageTitle(_pageAbout, "About");

            // App logo from resources
            var logoBox = new PictureBox
            {
                Image = Properties.Resources.logo1,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(0, 60),
                Size = new Size(220, 80),
                BackColor = Color.FromArgb(31, 32, 71)
            };

            var lblVersion = new Label
            {
                Text = "Version 1.0.0",
                Location = new Point(0, 148),
                Size = new Size(220, 22),
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = Color.Gray,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var separator = new Panel
            {
                Location = new Point(0, 178),
                Size = new Size(740, 1),
                BackColor = Color.FromArgb(220, 220, 230)
            };

            var lblDesc = new Label
            {
                Text =
                    "A personal desktop library manager for organizing and reading your PDF books.\r\n\r\n" +
                    "• Browse your full collection from the Home screen\r\n" +
                    "• Organize books into custom categories\r\n" +
                    "• Edit book details: title, author, notes, and tags\r\n" +
                    "• Automatic PDF cover preview generation",
                Location = new Point(0, 194),
                Size = new Size(700, 160),
                Font = new Font("Microsoft Sans Serif", 10F),
                ForeColor = Color.FromArgb(60, 60, 80)
            };

            var lblBuiltWith = new Label
            {
                Text = "Built with C# · Windows Forms · SQLite",
                Location = new Point(0, 366),
                Size = new Size(500, 22),
                Font = new Font("Microsoft Sans Serif", 9F),
                ForeColor = Color.Gray
            };

            var lblWho = new Label
            {
                Text = "Developed by Mazen Abdallah",
                Location = new Point(0, 392),
                Size = new Size(500, 22),
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 32, 71)
            };


            // ── Social Links ─────────────────────────────────────────────────────────────

            var lblConnect = new Label
            {
                Text = "Connect",
                Location = new Point(0, 428),
                Size = new Size(200, 20),
                Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold),
                ForeColor = Color.Gray
            };

            var picGitHub = new PictureBox
            {
                Image = Properties.Resources.github,
                SizeMode = PictureBoxSizeMode.Zoom,
                ForeColor = Color.FromArgb(31, 32, 71),
                Size = new Size(36, 36),
                Location = new Point(0, 452),
                Cursor = Cursors.Hand,
                Tag = "https://github.com/Mazen657"
            };

            var lblGitHub = new Label
            {
                Text = "GitHub",
                Location = new Point(42, 460),
                Size = new Size(80, 20),
                Font = new Font("Microsoft Sans Serif", 9F),
                ForeColor = Color.FromArgb(31, 32, 71),
                Cursor = Cursors.Hand,
                Tag = "https://github.com/Mazen657"   
            };

            var picLinkedIn = new PictureBox
            {
                Image = Properties.Resources.linkedin,
                SizeMode = PictureBoxSizeMode.Zoom,
                ForeColor = Color.FromArgb(31, 32, 71),
                Size = new Size(36, 36),
                Location = new Point(140, 452),
                Cursor = Cursors.Hand,
                Tag = "https://www.linkedin.com/in/mazen-abdallah-mohamed/"   
            };

            var lblLinkedIn = new Label
            {
                Text = "LinkedIn",
                Location = new Point(182, 460),
                Size = new Size(80, 20),
                Font = new Font("Microsoft Sans Serif", 9F),
                ForeColor = Color.FromArgb(0, 119, 181),
                Cursor = Cursors.Hand,
                Tag = "https://www.linkedin.com/in/mazen-abdallah-mohamed/"   
            };

            // Wire up clicks for all four controls
            foreach (Control ctrl in new Control[] { picGitHub, lblGitHub, picLinkedIn, lblLinkedIn })
            {
                ctrl.Click += (s, e) =>
                {
                    string url = ((Control)s).Tag?.ToString();
                    if (!string.IsNullOrEmpty(url))
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = url,
                            UseShellExecute = true
                        });
                };

                // Hover effect — underline label on mouse enter
                if (ctrl is Label lbl)
                {
                    lbl.MouseEnter += (s, e) => ((Label)s).Font =
                        new Font("Microsoft Sans Serif", 9F, FontStyle.Underline);
                    lbl.MouseLeave += (s, e) => ((Label)s).Font =
                        new Font("Microsoft Sans Serif", 9F);
                }
            }

            _pageAbout.Controls.AddRange(new Control[]
            {
    logoBox, lblVersion, separator, lblDesc,
    lblBuiltWith, lblWho,
    lblConnect, picGitHub, lblGitHub, picLinkedIn, lblLinkedIn
            });

            _panelContent.Controls.Add(_pageAbout);
        }

        #endregion

        #region Settings Load

        private void LoadCurrentSettings()
        {
            // Library page
            _txtDefaultFolder.Text = SettingsManager.Get(SettingsManager.KeyDefaultBookFolder);
            _chkAutoOpenLast.Checked = SettingsManager.GetBool(SettingsManager.KeyAutoOpenLastBook);

            // Appearance — mark the saved swatch
            int savedIdx = SettingsManager.GetInt(SettingsManager.KeyAccentColorIndex, 0);
            foreach (Control ctrl in _flowColors.Controls)
            {
                if (ctrl is Panel swatch && (int)swatch.Tag == savedIdx)
                    DrawSelectedBorder(swatch);
            }
        }

        #endregion

        #region Helpers

        private Panel CreateContentPage()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Visible = false
            };
        }

        private void AddPageTitle(Panel page, string text)
        {
            page.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(0, 8),
                Size = new Size(700, 40),
                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 32, 71)
            });

            page.Controls.Add(new Panel
            {
                Location = new Point(0, 50),
                Size = new Size(740, 1),
                BackColor = Color.FromArgb(200, 200, 220)
            });
        }

        private void AddSectionLabel(Panel page, string text, int top)
        {
            page.Controls.Add(new Label
            {
                Text = text,
                Location = new Point(0, top),
                Size = new Size(500, 24),
                Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 32, 71)
            });
        }

        private Label CreateDescLabel(string text, int top)
        {
            return new Label
            {
                Text = text,
                Location = new Point(0, top),
                Size = new Size(720, 28),
                Font = new Font("Microsoft Sans Serif", 9F),
                ForeColor = Color.Gray
            };
        }

        private void ShowSavedToast(string message)
        {
            // Non-blocking brief notification via a floating label
            var toast = new Label
            {
                Text = "✔  " + message,
                AutoSize = true,
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                Font = new Font("Microsoft Sans Serif", 9F),
                Padding = new Padding(8, 4, 8, 4)
            };

            _panelContent.Controls.Add(toast);
            toast.Location = new Point(
                _panelContent.Width - toast.Width - 20,
                _panelContent.Height - toast.Height - 20);
            toast.BringToFront();

            var timer = new System.Windows.Forms.Timer { Interval = 2000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                if (!toast.IsDisposed)
                    _panelContent.Controls.Remove(toast);
            };
            timer.Start();
        }

        #endregion
    }
}