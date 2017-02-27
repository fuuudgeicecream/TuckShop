using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuckShop.Models
{
    public class DbContextSeedData
    {
        
        public DbContextSeedData()
        {
        }
        public static async void Seed(IApplicationBuilder app)
        {
            // Get an instance of the DbContext from the DI container
            using (var context = app.ApplicationServices.GetRequiredService<Model>())
            {
                // perform database delete
                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Coca-Cola", Category = "Drinks", Description = "Refreshing Cool Drink.", Price = 9.00M },
                        new Product { Name = "Sprite", Category = "Drinks", Description = "Refreshing Cool Drink.", Price = 9.00M },
                        new Product { Name = "Sprite Zero", Category = "Drinks", Description = "Refreshing Cool Drink.", Price = 9.00M },
                        new Product { Name = "Beef Burger", Category = "Food", Description = "Home made style beef patty, with a crisp bun and onion relish.", Price = 25.00M },
                        new Product { Name = "Hawain Pizza", Category = "Food", Description = "Thin crust Pizza goodness.", Price = 45.00M },
                        new Product { Name = "Boerewors Roll", Category = "Food", Description = "Traditional Boerewors Roll.", Price = 22.50M },
                        new Product { Name = "Bar One", Category = "Sweets", Description = "Nougat, Caramel chocolate bar.", Price = 9.00M },
                        new Product { Name = "Lunch Bar", Category = "Sweets", Description = "Nutty centred chocolate bar", Price = 11.20M },
                        new Product { Name = "Fizz Pop", Category = "Sweets", Description = "Cherry flavoured.", Price = 5.00M });

                    var user = new ApplicationUser { UserName = "manager@canteen.co.za", Email = "manager@canteen.co.za" };
                    var _userManager = app.ApplicationServices.GetRequiredService < UserManager<ApplicationUser> > ();
                    var result = await _userManager.CreateAsync(user, "Exiter15.");
                    context.Users.Add(new User { Name = user.UserName, Email = user.Email, Role = "Customer", CellPhoneNumber = "111111111" });
                    context.SaveChanges();
                }
                //... perform other seed operations
            }

        }
    }
}
