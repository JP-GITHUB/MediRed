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
            var roles = userManager.GetRoles(User.Identity.GetUserId());

            if (roles.Contains("Medico"))
            {
                return RedirectToAction("Index", "Medics");
            }

            if (roles.Contains("Paciente"))
            {
                return RedirectToAction("Index", "Patients");
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