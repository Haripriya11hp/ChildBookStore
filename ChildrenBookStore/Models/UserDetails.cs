using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChildrenBookStore.Models
{
    public class UserDetails
    {
        public int UserDetails_id { get; set; }
        public string UserDetails_name { get; set; }
        public string UserDetails_email { get; set; }
        public string UserDetails_address { get; set; }
        public string UserDetails_state { get; set; }
        public int UserDetails_pincode { get; set; }
    }
}
