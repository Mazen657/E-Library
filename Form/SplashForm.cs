using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_app
{
    public partial class SplashForm : Form
    {
        #region Constants

        private const int StepDelay = 800;
        private const int FinalDelay = 1000;
        private const int ErrorDelay = 2000;
        private const int CornerRadius = 20;
        private const float LoadingTextY = 580f;

        #endregion

        #region Fields

        private string _loadingText = "Starting...";

        private readonly Font _loadingFont = new Font("Segoe UI", 11, FontStyle.Bold);

        #endregion

        #region Properties

        public bool AllChecksPassed { get; private set; } = true;
        public string ErrorMessage { get; private set; } = string.Empty;

        #endregion

        #region Constructor

        public SplashForm()
        {
            InitializeComponent();
            ConfigureForm();
        }

        #endregion

        #region Form Setup

        private void ConfigureForm()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            DoubleBuffered = true;
            Size = new Size(522, 666);
            BackColor = Color.Fuchsia;
            TransparencyKey = Color.Fuchsia;

            ApplyRoundedRegion();

            pictureBox1.Image = Properties.Resources.SplashForm;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Paint += OnPictureBoxPaint;
        }

        private void ApplyRoundedRegion()
        {
            using (var path = new GraphicsPath())
            {
                int w = Width;
                int h = Height;
                int r = CornerRadius;
                int d = r * 2;

                path.AddLine(0, 0, w - r, 0);
                path.AddArc(w - d, 0, d, d, 270, 90);
                path.AddLine(w, r, w, h - r);
                path.AddArc(w - d, h - d, d, d, 0, 90);
                path.AddLine(w - r, h, 0, h);
                path.AddLine(0, h, 0, 0);

                Region = new Region(path);
            }
        }

        #endregion

        #region Designer-Bound Handlers
        // SplashForm_Load must match the designer binding exactly — do not rename it.

        private async void SplashForm_Load(object sender, EventArgs e)
        {
            await RunStartupChecksAsync();
        }

        #endregion

        #region Loading Text

        private void OnPictureBoxPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            SizeF size = e.Graphics.MeasureString(_loadingText, _loadingFont);
            float x = (pictureBox1.Width - size.Width) / 2;

            e.Graphics.DrawString(_loadingText, _loadingFont, Brushes.White, x, LoadingTextY);
        }

        private void SetLoadingText(string text)
        {
            _loadingText = text;
            pictureBox1.Invalidate();
        }

        #endregion

        #region Startup Checks

        private async Task RunStartupChecksAsync()
        {
            var checks = new List<(string Label, Func<Task<bool>> Check)>
            {
                ("Database connection",  CheckDatabaseConnectionAsync),
                ("Database file",        CheckDatabaseFileAsync),
                ("System tables",        CheckRequiredTablesAsync),
                ("Write permissions",    CheckWritePermissionsAsync)
            };

            foreach (var (label, check) in checks)
            {
                SetLoadingText($"Checking {label}...");
                await Task.Delay(StepDelay);

                bool passed = await check();

                if (!passed)
                {
                    AllChecksPassed = false;
                    ErrorMessage = $"{label} check failed.";

                    SetLoadingText($"Error: {label} failed.");
                    await Task.Delay(ErrorDelay);

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                SetLoadingText($"{label} — OK");
                await Task.Delay(StepDelay);
            }

            SetLoadingText("Ready!");
            await Task.Delay(FinalDelay);

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion

        #region Individual Checks

        private Task<bool> CheckDatabaseConnectionAsync() => Task.Run(() =>
        {
            try
            {
                using (var connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch { return false; }
        });

        private Task<bool> CheckDatabaseFileAsync() => Task.Run(() =>
        {
            string dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "library.db");

            return File.Exists(dbPath);
        });

        private Task<bool> CheckRequiredTablesAsync() => Task.Run(() =>
        {
            try
            {
                return DatabaseHelper.GetExistingTables().Contains("Books");
            }
            catch { return false; }
        });

        private Task<bool> CheckWritePermissionsAsync() => Task.Run(() =>
        {
            try
            {
                string testPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "test.tmp");

                File.WriteAllText(testPath, "test");
                File.Delete(testPath);
                return true;
            }
            catch { return false; }
        });

        #endregion
    }
}