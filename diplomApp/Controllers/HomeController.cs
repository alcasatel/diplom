using diplomApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace diplomApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

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

        public ActionResult _userAvatar()
        {
            string userId = User.Identity.GetUserId();

            AddintionalUserInfo user = (from c in db.AddintionalUserInfos
                                        where c.UserId == userId
                                        select c).FirstOrDefault();
            return PartialView(user);
        }
    }
}