using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingLogin.Models;

namespace TrainingLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = "Test";

            return View();
        }


        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Password == "123456")
                {
                    Session["UserId"] = 1010;
                    return RedirectToAction("UserDashBoard");
                }
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserId"] != null)
            {
                User a = new User();
                
                a.Id = Int32.Parse(Session["UserId"].ToString());

                return View(a);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}