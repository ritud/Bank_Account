using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Bank_Account.Models;

namespace Bank_Account.Controllers
{
    public class HomeController : Controller
    {

        private UserContext _context;
        public HomeController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
        {
            User user = new User();
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.password = Hasher.HashPassword(user, model.password);
            user.first_name = model.first_name;
            user.last_name = model.last_name;
            user.email = model.email;
            _context.user.Add(user);
            _context.SaveChanges();
            int UserId = _context.user.Last().userid;
            HttpContext.Session.SetInt32("UserId", UserId);
            return Redirect($"/account/{UserId}");
        }
            return View("index");
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string Email, string Password)
        {
            User user= new User();
            if(ModelState.IsValid)
            {
                user = _context.user.Where(u => u.email == Email).SingleOrDefault();
            }

            if (user != null && Password != null)
            {
               // Console.WriteLine("********************************"+user.password);
                var Hasher = new PasswordHasher<User>();
               
                if(0 != Hasher.VerifyHashedPassword(user, user.password, Password))
                {
                    Console.WriteLine("********************************"+"Matched");
                    HttpContext.Session.SetInt32("UserId", user.userid);
                    return Redirect($"/account/{user.userid}");
                }
            }
            TempData["Error"] = "Invalid Email/Password Combination";
            return View("Login");
        }
    }
}

