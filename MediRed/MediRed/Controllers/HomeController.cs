using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediRed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.userRoles = userManager.GetRoles(User.Identity.GetUserId());
            }       

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