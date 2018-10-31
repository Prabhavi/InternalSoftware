using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackerModuleV1._0.Data;
using TrackerModuleV1._0.Models.PTM;


namespace TrackerModuleV1._0.Controllers
{
    public class Users2Controller : Controller
    {
        // GET: Users
        // GET: Account
        public ActionResult Index()
        {
            using (PTMContex db = new PTMContex())
            {
                return View(db.Users.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User account)
        {
            if (ModelState.IsValid)
            {
                using (PTMContex db = new PTMContex())
                {
                    db.Users.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered.";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using (PTMContex db = new PTMContex())
            {
                var usr = db.Users.Where(u => u.FirstName == user.FirstName && u.LastName == user.LastName).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["FirstName"] = usr.FirstName.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}