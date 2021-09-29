using Code_First_BookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( BookStore_Models.User login)
        {
            if (ModelState.IsValid)
            {
                CDBContext db = new CDBContext();
                var user = (from userlist in db.Users
                            where userlist.Email == login.Email && userlist.Password == login.Password
                            select new
                            {
                                userlist.ID,
                                userlist.Email
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["UserName"] = user.FirstOrDefault().Email;
                    Session["UserID"] = user.FirstOrDefault().ID;
                    return Redirect("/home/welcomepage");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }
        public ActionResult WelcomePage()
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
    }
}