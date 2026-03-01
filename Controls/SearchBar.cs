using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace library_app
{
    public partial class SearchBar : UserControl
    {
        #region Constants

        private const int MaxSuggestions = 5;
        private const int SuggestionHeight = 32;
        private const int SuggestionMargin = 4;
        private const int MaxDropdownHeight = 200;

        #endregion

        #region Events

        /// <summary>
        /// Raised when the user submits a search query, either by clicking
        /// the search button or selecting a suggestion.
        /// </summary>
        public event Action<string> OnSearch;

        #endregion

        #region Constructor

        public SearchBar()
        {
            InitializeComponent();

            txtSearchBar.TextChanged += OnTextChanged;
            btnSearch.Click += BtnSearch_Click;

            flowLayoutPanelSuggestions.SizeChanged += OnSuggestionPanelResized;
        }

        #endregion

        #region Designer-Bound Handlers
        // BtnSearch_Click must match the designer binding exactly — do not rename it.

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SubmitSearch(txtSearchBar.Text);
        }

        #endregion

        #region Search & Suggestions

        private void OnTextChanged(object sender, EventArgs e)
        {
            string query = txtSearchBar.Text.Trim();

            ClearSuggestions();

            if (string.IsNullOrEmpty(query)) return;

            var suggestions = BuildSuggestions(query);

            if (!suggestions.Any()) return;

            foreach (var suggestion in suggestions)
                flowLayoutPanelSuggestions.Controls.Add(CreateSuggestionButton(suggestion));

            int totalHeight = suggestions.Count * (SuggestionHeight + SuggestionMargin);
            flowLayoutPanelSuggestions.Height = Math.Min(totalHeight, MaxDropdownHeight);
            flowLayoutPanelSuggestions.Visible = true;
        }

        private List<string> BuildSuggestions(string query)
        {
            var books = DatabaseHelper.GetAllBooks();

            var titleMatches = books
                .Where(b => !string.IsNullOrEmpty(b.Title) &&
                            b.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(b => b.Title);

            var categoryMatches = books
                .SelectMany(b => ParseCategoryTags(b.Category))
                .Where(tag => tag.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                .Distinct(StringComparer.OrdinalIgnoreCase);

            return titleMatches
                .Concat(categoryMatches)
                .Take(MaxSuggestions)
                .ToList();
        }

        private Button CreateSuggestionButton(string text)
        {
            var button = new Button
            {
                Text = text,
                Height = SuggestionHeight,
                Width = flowLayoutPanelSuggestions.ClientSize.Width - 5,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(2),
                Padding = new Padding(5, 0, 0, 0),
                AutoSize = false
            };

            button.FlatAppearance.BorderSize = 0;
            button.Click += (s, e) =>
            {
                txtSearchBar.Text = text;
                SubmitSearch(text);
            };

            return button;
        }

        private void SubmitSearch(string query)
        {
            ClearSuggestions();
            OnSearch?.Invoke(query);
        }

        private void ClearSuggestions()
        {
            flowLayoutPanelSuggestions.Controls.Clear();
            flowLayoutPanelSuggestions.Visible = false;
        }

        #endregion

        #region Layout Handlers

        private void OnSuggestionPanelResized(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanelSuggestions.Controls)
                control.Width = flowLayoutPanelSuggestions.ClientSize.Width;
        }

        #endregion

        #region Parsing Helpers

        private List<string> ParseCategoryTags(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                return new List<string>();

            return category
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(tag => tag.Replace("_", " "))
                .ToList();
        }

        #endregion
    }
}