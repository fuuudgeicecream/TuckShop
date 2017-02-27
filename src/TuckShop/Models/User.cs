using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuckShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Role { get; set; }
        public List<Order> orders { get; set; }
    }
}
