using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.NET.Models;


namespace Project.NET.Controllers
{
    public class HomePageController : Controller
    {
        private Dbaccounts db = new Dbaccounts();
        // GET: HomePage
        [HttpGet]
        public ActionResult Index()
        {
            List<Account> acc = db.Accounts.ToList();
            ViewBag.acc = acc;
            return View();
        }
        public string About()
        {
            return "this is a custom About page!";
        }

        
    }
}