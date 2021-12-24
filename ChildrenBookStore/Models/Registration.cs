using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Models
{
    public class Registration
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string LoginEmail { get; set; }
        public string LoginPassword { get; set; }
    }
}
