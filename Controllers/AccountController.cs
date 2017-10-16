using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Bank_Account.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank_Account.Controllers
{
    public class AccountController : Controller
    {

        private UserContext _context;
        public AccountController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("/account/{id}")]
        public IActionResult Display(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (id != UserId)
            {
                return Redirect($"/account/{UserId}");
            }
            User user = _context.user.Include(u => u.Transactions).Where(u => u.userid == id).SingleOrDefault();

             if (user.Transactions != null)
            {
                user.Transactions = user.Transactions.OrderByDescending(wd => wd.transaction_date).ToList();
            }
            ViewBag.UserInfo = user;
            return View();
        }

        [HttpPost]
        [Route("transaction")]
        public IActionResult Transaction(int Amount)
        {
            Console.WriteLine("***************************************"+"IN ROUTE");
            int? UserId = HttpContext.Session.GetInt32("UserId");
            User user = _context.user.Where(u => u.userid == UserId).SingleOrDefault();
            if (Amount < 0 && ((Amount * -1) > user.amount))
            {
               TempData["Error"] = "Insufficient Funds";
            }    
            else
            {
                user.amount += Amount; // still a withdrawal because Amount is negative
                Console.WriteLine("***************************************"+user.amount);
                Transaction wd = new Transaction
                {
                    amount = Amount,
                    userid = (int)UserId,
                    transaction_date = DateTime.Now,
                };
                _context.transactions.Add(wd);
                _context.SaveChanges();
            }
            return Redirect($"/account/{UserId}"); 
        }
    }
}