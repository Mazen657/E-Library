using System;
using System.Windows.Forms;

namespace library_app
{
    public partial class CloseButton : UserControl
    {
        #region Events

        public event EventHandler CloseClicked;

        #endregion

        #region Constructor

        public CloseButton()
        {
            InitializeComponent();
        }

        #endregion

        #region Designer-Bound Handlers
        // These method names must match CloseButton.Designer.cs exactly — do not rename them.

        private void Close_Click(object sender, EventArgs e)
        {
            CloseClicked?.Invoke(this, EventArgs.Empty);
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