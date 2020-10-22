using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Books
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public string publication { get; set; }
        public string edition { get; set; }
    }
}
