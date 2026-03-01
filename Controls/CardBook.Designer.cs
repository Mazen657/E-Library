namespace library_app
{
    partial class CardBook
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
            this.CardBackground = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.CardBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // CardBackground
            // 
            this.CardBackground.BackColor = System.Drawing.Color.White;
            this.CardBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CardBackground.Controls.Add(this.btnDelete);
            this.CardBackground.Controls.Add(this.btnOpen);
            this.CardBackground.Controls.Add(this.lblTitle);
            this.CardBackground.Controls.Add(this.picCover);
            this.CardBackground.Location = new System.Drawing.Point(15, 11);
            this.CardBackground.Margin = new System.Windows.Forms.Padding(0);
            this.CardBackground.Name = "CardBackground";
            this.CardBackground.Size = new System.Drawing.Size(181, 325);
            this.CardBackground.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(15, 283);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(152, 27);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.Location = new System.Drawing.Point(15, 250);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(152, 27);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 211);
            this.lblTitle.MaximumSize = new System.Drawing.Size(153, 36);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 36);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "BookName";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(14, 12);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(153, 196);
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            this.picCover.Click += new System.EventHandler(this.pictureBoxCover_Click);
            // 
            // CardBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.CardBackground);
            this.Name = "CardBook";
            this.Size = new System.Drawing.Size(211, 356);
            this.CardBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CardBackground;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDelete;
    }
}
