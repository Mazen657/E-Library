namespace library_app
{
    partial class ControlWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Minimize = new System.Windows.Forms.PictureBox();
            this.Maximize = new System.Windows.Forms.PictureBox();
            this.Close = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Close);
            this.panel1.Location = new System.Drawing.Point(127, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 35);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Maximize);
            this.panel2.Location = new System.Drawing.Point(58, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(49, 35);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Minimize);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(38, 35);
            this.panel3.TabIndex = 0;
            // 
            // Minimize
            // 
            this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Minimize.Image = global::library_app.Properties.Resources.Minimize__1_;
            this.Minimize.Location = new System.Drawing.Point(0, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(38, 35);
            this.Minimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Minimize.TabIndex = 0;
            this.Minimize.TabStop = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // Maximize
            // 
            this.Maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Maximize.Image = global::library_app.Properties.Resources.Maximize;
            this.Maximize.Location = new System.Drawing.Point(0, 5);
            this.Maximize.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(49, 25);
            this.Maximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Maximize.TabIndex = 0;
            this.Maximize.TabStop = false;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // Close
            // 
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Close.Image = global::library_app.Properties.Resources.close_button1;
            this.Close.Location = new System.Drawing.Point(0, 0);
            this.Close.Margin = new System.Windows.Forms.Padding(0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(35, 35);
            this.Close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Close.TabIndex = 0;
            this.Close.TabStop = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            this.Close.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            this.Close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Close_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // ControlWindow
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ControlWindow";
            this.Size = new System.Drawing.Size(162, 35);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Maximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Maximize;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox Minimize;
    }
}
