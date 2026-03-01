namespace library_app
{
    partial class BooksForm
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

            this.fLPBook = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAddBackground = new System.Windows.Forms.Panel();
            this.panelAdd = new System.Windows.Forms.Panel();
            this.AddLogo = new System.Windows.Forms.PictureBox();
            this.fLPBook.SuspendLayout();
            this.panelAddBackground.SuspendLayout();
            this.panelAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // fLPBook
            // 
            this.fLPBook.Controls.Add(this.panelAddBackground);
            this.fLPBook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLPBook.Location = new System.Drawing.Point(0, 0);
            this.fLPBook.Name = "fLPBook";
            this.fLPBook.Size = new System.Drawing.Size(800, 450);
            this.fLPBook.TabIndex = 0;
            // 
            // panelAddBackground
            // 
            this.panelAddBackground.Controls.Add(this.panelAdd);
            this.panelAddBackground.Location = new System.Drawing.Point(3, 3);
            this.panelAddBackground.Name = "panelAddBackground";
            this.panelAddBackground.Size = new System.Drawing.Size(211, 356);
            this.panelAddBackground.TabIndex = 0;
            // 
            // panelAdd
            // 
            this.panelAdd.BackColor = System.Drawing.SystemColors.Window;
            this.panelAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdd.Controls.Add(this.AddLogo);
            this.panelAdd.Location = new System.Drawing.Point(13, 19);
            this.panelAdd.Name = "panelAdd";
            this.panelAdd.Size = new System.Drawing.Size(181, 325);
            this.panelAdd.TabIndex = 1;
            // 
            // AddLogo
            // 
            this.AddLogo.Image = global::library_app.Properties.Resources.add;
            this.AddLogo.Location = new System.Drawing.Point(64, 133);
            this.AddLogo.Name = "AddLogo";
            this.AddLogo.Size = new System.Drawing.Size(51, 50);
            this.AddLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddLogo.TabIndex = 0;
            this.AddLogo.TabStop = false;
            // 
            // BooksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fLPBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BooksForm";
            this.Text = "BooksForm";
            this.fLPBook.ResumeLayout(false);
            this.panelAddBackground.ResumeLayout(false);
            this.panelAdd.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLPBook;
        private System.Windows.Forms.Panel panelAddBackground;
        private System.Windows.Forms.PictureBox AddLogo;
        private System.Windows.Forms.Panel panelAdd;
    }
}