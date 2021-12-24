using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Models
{
    public class Books
    {
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string book_authorname { get; set; }
        public decimal book_price { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}
