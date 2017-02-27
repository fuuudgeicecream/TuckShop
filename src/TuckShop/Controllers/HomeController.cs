using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TuckShop.Models;

namespace TuckShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private Model _context;
        public HomeController(SignInManager<ApplicationUser> signInManager, Model context){
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (_context.Users.Any(a=>a.Email==User.Identities.First().Name))
                {
                    var user = _context.Users.Where(w => w.Email == User.Identities.First().Name).First();
                    if (user.Role == "Manager")
                    {
                        return RedirectToAction("Index", "Manager");
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
