using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using ToDoList.DataBase;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly Db _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Db db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult checkAccount(string email, string password) 
        {
            List<Account> accounts = _db.accounts.ToList();
            foreach (var account in accounts)
            {
                if(email.Equals(account.Email) && password.Equals(account.Password))
                {
                    return RedirectToAction("Mission","ToDo",account);

                }
            }
            
           return View("Index");
            
        }
        public IActionResult regestraion(Account account)
        {
            if(ModelState.IsValid)
            {
                _db.accounts.Add(account);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
