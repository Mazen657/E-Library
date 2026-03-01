namespace library_app
{
    partial class BookDetailsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnEditNotes = new System.Windows.Forms.Button();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.btnEditCategory = new System.Windows.Forms.Button();
            this.btnEditAuthor = new System.Windows.Forms.Button();
            this.btnEditTitle = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPdfPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(61, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(12, 95);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(82, 29);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(531, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(231, 39);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(531, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(231, 39);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(12, 182);
            this.lblCategory.MaximumSize = new System.Drawing.Size(501, 59);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(110, 29);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Category";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = true;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(12, 338);
            this.txtDescription.MaximumSize = new System.Drawing.Size(499, 241);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(135, 29);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.Text = "Description";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.Enabled = false;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(17, 43);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(468, 49);
            this.txtTitle.TabIndex = 7;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Enabled = false;
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(17, 127);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(468, 44);
            this.txtAuthor.TabIndex = 7;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Enabled = false;
            this.txtCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(17, 214);
            this.txtCategory.Multiline = true;
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(468, 56);
            this.txtCategory.TabIndex = 7;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Enabled = false;
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(17, 370);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Size = new System.Drawing.Size(468, 68);
            this.txtNotes.TabIndex = 7;
            // 
            // btnEditNotes
            // 
            this.btnEditNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditNotes.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditNotes.FlatAppearance.BorderSize = 0;
            this.btnEditNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNotes.Image = global::library_app.Properties.Resources.compose__1_;
            this.btnEditNotes.Location = new System.Drawing.Point(485, 408);
            this.btnEditNotes.Name = "btnEditNotes";
            this.btnEditNotes.Size = new System.Drawing.Size(30, 30);
            this.btnEditNotes.TabIndex = 8;
            this.btnEditNotes.UseVisualStyleBackColor = false;
            this.btnEditNotes.Click += new System.EventHandler(this.btnEditNotes_Click);
            // 
            // picCover
            // 
            this.picCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCover.Location = new System.Drawing.Point(531, 43);
            this.picCover.MaximumSize = new System.Drawing.Size(462, 610);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(231, 305);
            this.picCover.TabIndex = 1;
            this.picCover.TabStop = false;
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCategory.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditCategory.FlatAppearance.BorderSize = 0;
            this.btnEditCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCategory.Image = global::library_app.Properties.Resources.compose__1_;
            this.btnEditCategory.Location = new System.Drawing.Point(485, 240);
            this.btnEditCategory.Name = "btnEditCategory";
            this.btnEditCategory.Size = new System.Drawing.Size(30, 30);
            this.btnEditCategory.TabIndex = 9;
            this.btnEditCategory.UseVisualStyleBackColor = false;
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnEditAuthor
            // 
            this.btnEditAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAuthor.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditAuthor.FlatAppearance.BorderSize = 0;
            this.btnEditAuthor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAuthor.Image = global::library_app.Properties.Resources.compose__1_;
            this.btnEditAuthor.Location = new System.Drawing.Point(485, 141);
            this.btnEditAuthor.Name = "btnEditAuthor";
            this.btnEditAuthor.Size = new System.Drawing.Size(30, 30);
            this.btnEditAuthor.TabIndex = 10;
            this.btnEditAuthor.UseVisualStyleBackColor = false;
            this.btnEditAuthor.Click += new System.EventHandler(this.btnEditAuthor_Click);
            // 
            // btnEditTitle
            // 
            this.btnEditTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTitle.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditTitle.FlatAppearance.BorderSize = 0;
            this.btnEditTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTitle.Image = global::library_app.Properties.Resources.compose__1_;
            this.btnEditTitle.Location = new System.Drawing.Point(485, 62);
            this.btnEditTitle.Name = "btnEditTitle";
            this.btnEditTitle.Size = new System.Drawing.Size(30, 30);
            this.btnEditTitle.TabIndex = 11;
            this.btnEditTitle.UseVisualStyleBackColor = false;
            this.btnEditTitle.Click += new System.EventHandler(this.btnEditTitle_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(12, 276);
            this.lblPath.MaximumSize = new System.Drawing.Size(499, 241);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(97, 29);
            this.lblPath.TabIndex = 6;
            this.lblPath.Text = "PdfPath";
            // 
            // txtPdfPath
            // 
            this.txtPdfPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPdfPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPdfPath.Enabled = false;
            this.txtPdfPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPdfPath.Location = new System.Drawing.Point(17, 306);
            this.txtPdfPath.Name = "txtPdfPath";
            this.txtPdfPath.ReadOnly = true;
            this.txtPdfPath.Size = new System.Drawing.Size(468, 29);
            this.txtPdfPath.TabIndex = 7;
            // 
            // BookDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.btnEditTitle);
            this.Controls.Add(this.btnEditAuthor);
            this.Controls.Add(this.btnEditCategory);
            this.Controls.Add(this.btnEditNotes);
            this.Controls.Add(this.txtPdfPath);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.picCover);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookDetailsForm";
            this.Text = "BookDetailsForm";
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label txtDescription;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnEditNotes;
        private System.Windows.Forms.Button btnEditCategory;
        private System.Windows.Forms.Button btnEditAuthor;
        private System.Windows.Forms.Button btnEditTitle;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPdfPath;
    }
}