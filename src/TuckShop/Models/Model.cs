using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TuckShop.Models
{
    public class Model : DbContext
    {
        public Model(DbContextOptions<Model> options): base(options)
        { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
