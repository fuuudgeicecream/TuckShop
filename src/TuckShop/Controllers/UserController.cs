using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TuckShop.Models;
using System.Threading;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TuckShop.BusinessLogic;
using Microsoft.Extensions.Logging;

namespace TuckShop.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private Model _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        public UserController(ILoggerFactory loggerFactory, Model context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _logger = loggerFactory.CreateLogger<UserController>();
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
           var claim =  _signInManager.IsSignedIn(User);
            return View();
        }
        [HttpPost]
        public IActionResult AllProducts()
        {
            var model = _context.Products.ToList();
            var drinks = model.Where(w => w.Category == "Drinks").ToList();
            var food = model.Where(w => w.Category == "Food").ToList();
            var sweets = model.Where(w => w.Category == "Sweets").ToList();
            return Json(new { Drinks = drinks, Food = food, Sweets = sweets, success = true });
        }

        [HttpPost]
        public IActionResult ByCategory(string id)
        {
            var model = _context.Products.Where(w => w.Category == id).ToList();
            return Json(new { list = model, success = true });
        }
        [HttpPost]
        public IActionResult PlaceOrder(List<OrderInputModel> list)
        {
            var user = new User();
            if (_context.Users.Any(a => a.Email == User.Identities.First().Name))
            {
                user = _context.Users.Where(w => w.Email == User.Identities.First().Name).First();
            }
            ProcessOrder processOrder = new ProcessOrder();
            var response = processOrder.processOrderTask(list,user);
            var order = response.order;
            if (_context.Orders.Any())
            {
                var previousRef = _context.Orders.First().Id;
                order.Reference = (previousRef + 1).ToString();
            }else
            {
                order.Reference = 1.ToString();
            }
            try
            {
                _context.Orders.Add(order);
                foreach (var item in response.lineItems)
                {
                    item.OrderId = order.Id;
                    _context.LineItems.Add(item);
                }
            }catch(Exception ex)
            {
                _logger.LogError("Failed to map LineItems and Order, check ProcessOrder Class.");
            }
            try
            {
                _context.SaveChanges();
            }catch(Exception ex)
            {
                _logger.LogError("Failed to save Order.");
            }
            finally
            {
                _context.Dispose();
            }
                    
            return Json(new { success = true, message = "Your Order has been submitted." });
        }
    }
}