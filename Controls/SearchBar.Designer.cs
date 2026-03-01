namespace library_app
{
    partial class SearchBar
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
            this.txtSearchBar = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelSuggestions = new System.Windows.Forms.FlowLayoutPanel();
            this.TitlePage = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchBar
            // 
            this.txtSearchBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBar.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBar.Multiline = true;
            this.txtSearchBar.Name = "txtSearchBar";
            this.txtSearchBar.Size = new System.Drawing.Size(261, 41);
            this.txtSearchBar.TabIndex = 1;
            // 
            // flowLayoutPanelSuggestions
            // 
            this.flowLayoutPanelSuggestions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelSuggestions.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelSuggestions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelSuggestions.Location = new System.Drawing.Point(0, 44);
            this.flowLayoutPanelSuggestions.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelSuggestions.Name = "flowLayoutPanelSuggestions";
            this.flowLayoutPanelSuggestions.Size = new System.Drawing.Size(261, 109);
            this.flowLayoutPanelSuggestions.TabIndex = 2;
            this.flowLayoutPanelSuggestions.Visible = false;
            this.flowLayoutPanelSuggestions.WrapContents = false;
            // 
            // TitlePage
            // 
            this.TitlePage.AutoSize = true;
            this.TitlePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitlePage.Location = new System.Drawing.Point(-10, 54);
            this.TitlePage.Name = "TitlePage";
            this.TitlePage.Size = new System.Drawing.Size(205, 57);
            this.TitlePage.TabIndex = 3;
            this.TitlePage.Text = "BOOKS";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(32)))), ((int)(((byte)(71)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = global::library_app.Properties.Resources.search;
            this.btnSearch.Location = new System.Drawing.Point(260, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(44, 41);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // SearchBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanelSuggestions);
            this.Controls.Add(this.TitlePage);
            this.Controls.Add(this.txtSearchBar);
            this.Controls.Add(this.btnSearch);
            this.Name = "SearchBar";
            this.Size = new System.Drawing.Size(304, 163);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSuggestions;
        private System.Windows.Forms.Label TitlePage;
    }
}
