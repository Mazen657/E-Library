using System;
using System.Windows.Forms;

namespace library_app
{
    public partial class ControlWindow : UserControl
    {
        #region Events

        public event EventHandler CloseClicked;
        public event EventHandler MinimizeClicked;
        public event EventHandler MaximizeClicked;

        #endregion

        #region Constructor

        public ControlWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Public API

        /// <summary>
        /// Switches the maximize button icon to the standard maximize image.
        /// Call this when the window is in its normal (restored) state.
        /// </summary>
        public void SetMaximizeIcon()
        {
            Maximize.Image = Properties.Resources.Maximize;
        }

        /// <summary>
        /// Switches the maximize button icon to the restore-down image.
        /// Call this when the window is maximized.
        /// </summary>
        public void SetMinimizeIcon()
        {
            Maximize.Image = Properties.Resources.restore_down;
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match ControlWindow.Designer.cs exactly — do not rename them.

        private void Close_Click(object sender, EventArgs e)
        {
            CloseClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            MinimizeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            MaximizeClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            Close.Image = Properties.Resources.close2;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Close.Image = Properties.Resources.close_button1;
        }

        #endregion
    }
}