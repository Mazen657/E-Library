using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_app
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public string PdfPath { get; set; }
        public Image Cover { get; set; }
        public DateTime LastOpened { get; set; }
    }


}
