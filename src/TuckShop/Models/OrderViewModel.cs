using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuckShop.Models
{
    public class OrderViewModel
    {
    }
    public class OrderInputModel
    {
        public string ProductId { get; set; }
        public int Count { get; set; }
    }


    public class ProcessOrderResponseModel
    {
        public List<LineItem> lineItems { get; set; }
        public Order order { get; set; }
    }
}
