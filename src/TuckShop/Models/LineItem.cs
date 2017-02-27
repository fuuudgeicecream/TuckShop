using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuckShop.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Order order { get; set; }
        public Product product { get; set; }
    }
}
