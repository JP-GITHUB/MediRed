using MediRed.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediRed.Controllers
{
    public class SetRolesController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SetRoles
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));            
            var lstUserVm = new List<UserViewModel>();

            foreach (var user in userManager.Users)
            {
                var userVm = new UserViewModel()
                {
                    UserId= user.Id,
                    UserName= user.UserName,
                    Email = user.Email
                };
                lstUserVm.Add(userVm);
            }         
            return View(lstUserVm);
        }
        public ActionResult Roles(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.FindById(id);
            var lstRoleVm = new List<RoleViewModel>();

            foreach(var roleUser in user.Roles)
            {
                var role = roleManager.FindById(roleUser.RoleId);
                var newRolVm = new RoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                lstRoleVm.Add(newRolVm);
            }

            var userVm = new UserViewModel()
            {
                UserId= user.Id,
                Email= user.Email,
                UserName= user.UserName,
                Roles = lstRoleVm
            };
            return View(userVm);
        }
    }
}