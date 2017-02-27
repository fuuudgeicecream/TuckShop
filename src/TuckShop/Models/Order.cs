using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuckShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string Size { get; set; }
        public int UserId { get; set; }
        
        public List<LineItem> LineItems { get; set; }
        public User user { get; set; }
    }
}
