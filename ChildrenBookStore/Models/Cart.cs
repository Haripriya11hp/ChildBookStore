using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Models
{
    public class Cart
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string photo { get; set; }
        public int price { get; set; }
    }
}
