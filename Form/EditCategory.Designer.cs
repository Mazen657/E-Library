namespace library_app
{
    partial class EditCategory
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
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxAddBook = new System.Windows.Forms.ComboBox();
            this.txtNameCategory = new System.Windows.Forms.TextBox();
            this.lblNameCategory = new System.Windows.Forms.Label();
            this.lblAddBook = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.closeButton1 = new library_app.CloseButton();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panelTitleBar.Controls.Add(this.closeButton1);
            this.panelTitleBar.Controls.Add(this.Title);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(242, 40);
            this.panelTitleBar.TabIndex = 1;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(117, 24);
            this.Title.TabIndex = 1;
            this.Title.Text = "EditCategory";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(238, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 169);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 205);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 4);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 165);
            this.panel3.TabIndex = 4;
            // 
            // comboBoxAddBook
            // 
            this.comboBoxAddBook.FormattingEnabled = true;
            this.comboBoxAddBook.Location = new System.Drawing.Point(16, 125);
            this.comboBoxAddBook.Name = "comboBoxAddBook";
            this.comboBoxAddBook.Size = new System.Drawing.Size(208, 21);
            this.comboBoxAddBook.TabIndex = 5;
            // 
            // txtNameCategory
            // 
            this.txtNameCategory.Location = new System.Drawing.Point(16, 76);
            this.txtNameCategory.Name = "txtNameCategory";
            this.txtNameCategory.Size = new System.Drawing.Size(208, 20);
            this.txtNameCategory.TabIndex = 6;
            // 
            // lblNameCategory
            // 
            this.lblNameCategory.AutoSize = true;
            this.lblNameCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameCategory.Location = new System.Drawing.Point(11, 57);
            this.lblNameCategory.Name = "lblNameCategory";
            this.lblNameCategory.Size = new System.Drawing.Size(44, 16);
            this.lblNameCategory.TabIndex = 7;
            this.lblNameCategory.Text = "Name";
            // 
            // lblAddBook
            // 
            this.lblAddBook.AutoSize = true;
            this.lblAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddBook.Location = new System.Drawing.Point(11, 106);
            this.lblAddBook.Name = "lblAddBook";
            this.lblAddBook.Size = new System.Drawing.Size(67, 16);
            this.lblAddBook.TabIndex = 7;
            this.lblAddBook.Text = "Add Book";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 175);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(122, 175);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // closeButton1
            // 
            this.closeButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.closeButton1.Location = new System.Drawing.Point(203, 2);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(35, 35);
            this.closeButton1.TabIndex = 2;
            // 
            // EditCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 209);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAddBook);
            this.Controls.Add(this.lblNameCategory);
            this.Controls.Add(this.txtNameCategory);
            this.Controls.Add(this.comboBoxAddBook);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCategory";
            this.Text = "EditCategory";
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxAddBook;
        private System.Windows.Forms.TextBox txtNameCategory;
        private System.Windows.Forms.Label lblNameCategory;
        private System.Windows.Forms.Label lblAddBook;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private CloseButton closeButton1;
    }
}