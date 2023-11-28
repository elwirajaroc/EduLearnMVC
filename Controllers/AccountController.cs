using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EduLearnMVC.Models;

namespace EduLearnMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        MyDbContext db = new MyDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account log)
        {
            var user = db.Accounts.Where(x => x.Username == log.Username && x.Password == log.Password).Count();
            if(user > 0)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Dashboard()
        {
            return View();
        }

    }
}