using PdfiumViewer;
using System;
using System.Drawing;
using System.IO;

namespace library_app
{
    public static class PdfCoverHelper
    {
        // The folder where GenerateCover() writes its PNG files.
        // BaseDirectory keeps it next to the .exe, matching the original behaviour.
        private static readonly string _coversDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Covers");

        public static string GenerateCover(string pdfPath, int width = 300, int height = 400)
        {
            if (!File.Exists(pdfPath))
                return string.Empty;

            Directory.CreateDirectory(_coversDir);

            string imagePath = Path.Combine(
                _coversDir,
                Path.GetFileNameWithoutExtension(pdfPath) + ".png");

            if (File.Exists(imagePath))
                return imagePath;

            using (var document = PdfDocument.Load(pdfPath))
            using (var image = document.Render(0, width, height, true))
            {
                image.Save(imagePath);
            }

            return imagePath;
        }

        /// <summary>
        /// Returns the folder where cover images are cached.
        /// Must exactly match the directory used by GenerateCover().
        /// </summary>
        public static string GetCacheDirectory() => _coversDir;
    }
}