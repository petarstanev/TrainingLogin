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

        public ActionResult Logout()
        {
            Session["UserName"] = null;
            return RedirectToAction(String.Empty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (GroupOfUsers.Users.Any(n => n.Username == user.Username && n.Password == user.Password))
                {
                    Session["UserName"] = user.Username;
                    return RedirectToAction("UserDashBoard");
                }
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserName"] != null)
            {
                User a = new User();

                a.Username = Session["UserName"].ToString();

                return View(a);
            }
            else
            {
                return RedirectToAction("UserDashBoard");
            }
        }

        public ActionResult Register()
        {
            if (Session["UserId"] != null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                GroupOfUsers.Users.Add(user);
             
                return RedirectToAction("Login");
            }
            return View();
        }

        public PartialViewResult LoginHeaderView()
        {
            if (Session["UserName"] != null)
            {
                return PartialView(LoginStatus.Login);
            }

            return PartialView(LoginStatus.Logout);
        }
    }
}