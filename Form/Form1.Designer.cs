namespace library_app
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.controlWindow1 = new library_app.ControlWindow();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.btnSetting);
            this.panelMenu.Controls.Add(this.btnCategories);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Location = new System.Drawing.Point(2, 5);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(218, 592);
            this.panelMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(220, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 90);
            this.panel1.TabIndex = 4;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(218, 98);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panelTitleBar.Controls.Add(this.controlWindow1);
            this.panelTitleBar.Controls.Add(this.picBack);
            this.panelTitleBar.Location = new System.Drawing.Point(220, 5);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1019, 39);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.BackColorChanged += new System.EventHandler(this.ColorPanel);
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.SystemColors.Control;
            this.panelMain.Location = new System.Drawing.Point(220, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1019, 557);
            this.panelMain.TabIndex = 2;
            // 
            // btnSetting
            // 
            this.btnSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.FlatAppearance.BorderSize = 0;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnSetting.Image = global::library_app.Properties.Resources.settings;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(0, 532);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnSetting.Size = new System.Drawing.Size(220, 60);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "   Settings";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategories.FlatAppearance.BorderSize = 0;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCategories.Image = global::library_app.Properties.Resources.Categroies;
            this.btnCategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.Location = new System.Drawing.Point(0, 158);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCategories.Size = new System.Drawing.Size(218, 60);
            this.btnCategories.TabIndex = 2;
            this.btnCategories.Text = "   Categories";
            this.btnCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnHome.Image = global::library_app.Properties.Resources.home__1_;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(0, 98);
            this.btnHome.Name = "btnHome";
            this.btnHome.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHome.Size = new System.Drawing.Size(218, 60);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "   Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::library_app.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.picBack.Image = global::library_app.Properties.Resources.arrow;
            this.picBack.Location = new System.Drawing.Point(6, 6);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(39, 26);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBack.TabIndex = 1;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // controlWindow1
            // 
            this.controlWindow1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.controlWindow1.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlWindow1.Location = new System.Drawing.Point(857, 0);
            this.controlWindow1.Name = "controlWindow1";
            this.controlWindow1.Size = new System.Drawing.Size(162, 39);
            this.controlWindow1.TabIndex = 0;
            this.controlWindow1.Load += new System.EventHandler(this.controlWindow1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(1241, 600);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Panel panelTitleBar;
        private ControlWindow controlWindow1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBack;
    }
}

