using System;
using System.Collections.Generic;
using System.IO;

namespace library_app
{
    /// <summary>
    /// Reads and writes application settings to a plain key=value config file
    /// stored in the user's application data folder. No external dependencies required.
    /// </summary>
    public static class SettingsManager
    {
        #region Keys

        public const string KeyDefaultBookFolder = "DefaultBookFolder";
        public const string KeyAutoOpenLastBook = "AutoOpenLastBook";
        public const string KeyAccentColorIndex = "AccentColorIndex";

        #endregion

        #region File Path

        private static readonly string _configDir =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LibraryApp");

        private static readonly string _configPath =
            Path.Combine(_configDir, "settings.cfg");

        #endregion

        #region In-memory Store

        private static Dictionary<string, string> _store;

        private static Dictionary<string, string> Store
        {
            get
            {
                if (_store == null) Load();
                return _store;
            }
        }

        #endregion

        #region Public API

        public static string Get(string key, string defaultValue = "")
        {
            return Store.TryGetValue(key, out string value) ? value : defaultValue;
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            string raw = Get(key);
            if (string.IsNullOrEmpty(raw)) return defaultValue;
            return raw.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            string raw = Get(key);
            return int.TryParse(raw, out int result) ? result : defaultValue;
        }

        public static void Set(string key, string value)
        {
            Store[key] = value ?? string.Empty;
            Save();
        }

        public static void Set(string key, bool value) => Set(key, value ? "true" : "false");
        public static void Set(string key, int value) => Set(key, value.ToString());

        #endregion

        #region Load / Save

        private static void Load()
        {
            _store = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            if (!File.Exists(_configPath)) return;

            foreach (string line in File.ReadAllLines(_configPath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

                int idx = line.IndexOf('=');
                if (idx <= 0) continue;

                string key = line.Substring(0, idx).Trim();
                string value = line.Substring(idx + 1).Trim();

                _store[key] = value;
            }
        }

        private static void Save()
        {
            Directory.CreateDirectory(_configDir);

            var lines = new List<string> { "# LibraryApp Settings — do not edit manually", "" };

            foreach (var pair in _store)
                lines.Add($"{pair.Key}={pair.Value}");

            File.WriteAllLines(_configPath, lines);
        }

        #endregion
    }
}