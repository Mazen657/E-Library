namespace library_app
{
    partial class AddBookForm
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
            this.components = new System.ComponentModel.Container();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblPdf = new System.Windows.Forms.Label();
            this.txtPdfPath = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelDropPdf = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.TextBox();
            this.pictureBoxCover = new System.Windows.Forms.PictureBox();
            this.closeButton1 = new library_app.CloseButton();
            this.panelTitleBar.SuspendLayout();
            this.panelDropPdf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).BeginInit();
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
            this.panelTitleBar.Size = new System.Drawing.Size(379, 40);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(22, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(93, 24);
            this.Title.TabIndex = 1;
            this.Title.Text = "Add Book";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(25, 219);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(35, 18);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(28, 240);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(163, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(25, 271);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(51, 18);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(28, 292);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(163, 20);
            this.txtAuthor.TabIndex = 3;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(25, 447);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(40, 18);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "Note";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(28, 468);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(322, 64);
            this.txtNotes.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(25, 328);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(68, 18);
            this.lblCategory.TabIndex = 1;
            this.lblCategory.Text = "Category";
            // 
            // lblPdf
            // 
            this.lblPdf.AutoSize = true;
            this.lblPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPdf.Location = new System.Drawing.Point(25, 385);
            this.lblPdf.Name = "lblPdf";
            this.lblPdf.Size = new System.Drawing.Size(72, 18);
            this.lblPdf.TabIndex = 1;
            this.lblPdf.Text = "PDF Path";
            // 
            // txtPdfPath
            // 
            this.txtPdfPath.Location = new System.Drawing.Point(28, 406);
            this.txtPdfPath.Multiline = true;
            this.txtPdfPath.Name = "txtPdfPath";
            this.txtPdfPath.Size = new System.Drawing.Size(250, 29);
            this.txtPdfPath.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(275, 558);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(182, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelDropPdf
            // 
            this.panelDropPdf.AllowDrop = true;
            this.panelDropPdf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelDropPdf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDropPdf.Controls.Add(this.label1);
            this.panelDropPdf.Location = new System.Drawing.Point(28, 54);
            this.panelDropPdf.Name = "panelDropPdf";
            this.panelDropPdf.Size = new System.Drawing.Size(321, 155);
            this.panelDropPdf.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag, Drop PDF Here";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(374, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 564);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 564);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 599);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 5);
            this.panel3.TabIndex = 10;
            // 
            // btnBrowser
            // 
            this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowser.Location = new System.Drawing.Point(275, 406);
            this.btnBrowser.Margin = new System.Windows.Forms.Padding(0);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 29);
            this.btnBrowser.TabIndex = 11;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(28, 349);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(163, 20);
            this.cmbCategory.TabIndex = 3;
            // 
            // pictureBoxCover
            // 
            this.pictureBoxCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCover.Location = new System.Drawing.Point(214, 219);
            this.pictureBoxCover.Name = "pictureBoxCover";
            this.pictureBoxCover.Size = new System.Drawing.Size(136, 150);
            this.pictureBoxCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCover.TabIndex = 5;
            this.pictureBoxCover.TabStop = false;
            this.pictureBoxCover.Visible = false;
            // 
            // closeButton1
            // 
            this.closeButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.closeButton1.Location = new System.Drawing.Point(339, 2);
            this.closeButton1.Name = "closeButton1";
            this.closeButton1.Size = new System.Drawing.Size(35, 35);
            this.closeButton1.TabIndex = 2;
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 604);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDropPdf);
            this.Controls.Add(this.pictureBoxCover);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtPdfPath);
            this.Controls.Add(this.lblPdf);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddBookForm";
            this.Text = "AddBookForm";
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDropPdf.ResumeLayout(false);
            this.panelDropPdf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblPdf;
        private System.Windows.Forms.TextBox txtPdfPath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBoxCover;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelDropPdf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox cmbCategory;
        private CloseButton closeButton1;
    }
}