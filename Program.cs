using SQLitePCL;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace library_app
{
    internal static class Program
    {
        #region Win32 — bring existing window to front

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        // nCmdShow values
        private const int SW_RESTORE = 9;
        private const int SW_SHOW = 5;

        #endregion

        #region Entry Point

        [STAThread]
        static void Main()
        {
            // ── Single-instance guard ─────────────────────────────────────────
            // The mutex name must be unique to this app. Using the app name +
            // a fixed GUID ensures no collision with other software.
            const string MutexName = "LibraryApp_SingleInstance_{A1B2C3D4-E5F6-7890-ABCD-EF1234567890}";

            bool createdNew;
            using (var mutex = new Mutex(initiallyOwned: true, MutexName, out createdNew))
            {
                if (!createdNew)
                {
                    // Another instance is already running — bring it to the front
                    BringExistingInstanceToFront();
                    return;
                }

                // ── Normal startup ────────────────────────────────────────────
                SQLitePCL.Batteries.Init();
                DatabaseHelper.CreateDatabaseAndTables();
                DatabaseHelper.AddLastOpenedColumnIfNotExists();
                DatabaseHelper.CreateCategoriesTable();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                using (var splash = new SplashForm())
                {
                    if (splash.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new Form1());
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Failed to start the application:\n{splash.ErrorMessage}",
                            "Startup Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }

                // Release the mutex when the app closes so it can be reopened
                mutex.ReleaseMutex();
            }
        }

        #endregion

        #region Bring Existing Window to Front

        /// <summary>
        /// Finds the already-running instance's main window and brings it
        /// to the foreground, restoring it if it was minimised.
        /// </summary>
        private static void BringExistingInstanceToFront()
        {
            // Get the current process name so we can find the other instance
            string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            foreach (var process in System.Diagnostics.Process.GetProcessesByName(processName))
            {
                // Skip ourselves
                if (process.Id == System.Diagnostics.Process.GetCurrentProcess().Id)
                    continue;

                IntPtr hWnd = process.MainWindowHandle;

                if (hWnd == IntPtr.Zero)
                    continue;

                // Restore if minimised, then bring to front
                if (IsIconic(hWnd))
                    ShowWindow(hWnd, SW_RESTORE);
                else
                    ShowWindow(hWnd, SW_SHOW);

                SetForegroundWindow(hWnd);
                break;
            }
        }

        #endregion
    }
}