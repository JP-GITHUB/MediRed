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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var lstUserVm = new List<UserViewModel>();

            foreach (var user in userManager.Users)
            {
                var userVm = new UserViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };
                lstUserVm.Add(userVm);
            }
            return View(lstUserVm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Roles(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.FindById(id);
            var lstRoleVm = new List<RoleViewModel>();

            foreach (var roleUser in user.Roles)
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
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = lstRoleVm
            };
            return View(userVm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AddRole(string id)
        {
            // Se invocan los manager y se crean las variables que se utilizaran

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roles = roleManager.Roles;
            var user = userManager.FindById(id);
            var lstRoleVm = new List<RoleViewModel>();

            //Se iterará primero en todas las variables de la lista de roles del manager

            foreach (var role in roles)
            {
                var newRolVm = new RoleViewModel()
                {
                    //Una vez conseguidas las variables, se asignan las propiedades a cada una
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                //Finalmente, se construye una lista con las variables que se han creado
                lstRoleVm.Add(newRolVm);
            }
            //Luego de terminado con los roles, se hace lo mismo con los usuarios del UserManager
            var userVm = new UserViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName

            };

            //Para finalizar, la lista de roles conseguida se inserta en el dropdown creado en la vista

            lstRoleVm.Insert(0, new RoleViewModel() { RoleName = " Seleccione un Rol " });
            ViewBag.RolesId = new SelectList(lstRoleVm, "RoleId", "RoleName");   
            return View(userVm);   //En la vista se muestra la lista de usuarios con sus roles asignados.
        }

        //Se le enviará por método post al formulario dos objetos: userId y un formcollection
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddRole(string userId, FormCollection frm)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindById(userId);
            var roleId = Request["RolesId"];    //Además de recuperar el usuario, debo recuperar la variable de rol a trvés de la sentencia request del formulario.
            var role = roleManager.FindById(roleId);

            //Se verifica si el usuario tenia el rol, y si no lo tiene se le agrega

            if (!userManager.IsInRole(user.Id, role.Name))
            {
                userManager.AddToRole(user.Id, role.Name);
            }
            //Se construye la lista de roles

            var lstRoleVm = new List<RoleViewModel>();
            foreach (var roleUser in user.Roles)
            {
                var roleU = roleManager.FindById(roleUser.RoleId);
                var newRolVm = new RoleViewModel()
                {
                    RoleId = roleU.Id,
                    RoleName = roleU.Name
                };

                lstRoleVm.Add(newRolVm);
            }
            var userVm = new UserViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = lstRoleVm
            };
            //se retorna a la vista de roles con el usuario al que se le asigno el rol
            return View("Roles", userVm);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole (string userId, string roleId)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userManager.FindById(userId);
            var role = roleManager.FindById(roleId);

            if (userManager.IsInRole(user.Id, role.Name))
            {
                userManager.RemoveFromRoles(user.Id, role.Name);
            }

            //Se construye la lista de roles

            var lstRoleVm = new List<RoleViewModel>();
            foreach (var roleUser in user.Roles)
            {
                var roleU = roleManager.FindById(roleUser.RoleId);
                var newRolVm = new RoleViewModel()
                {
                    RoleId = roleU.Id,
                    RoleName = roleU.Name
                };

                lstRoleVm.Add(newRolVm);
            }
            var userVm = new UserViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = lstRoleVm
            };
            //se retorna a la vista de roles una vez removido el rol del usuario
            return View("Roles", userVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole(string RoleName, FormCollection frm)
        {
            //Instanciar un manager de roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(RoleName))
            {
                //var role = roleManager.FindByName(newRole);
                var rol = new IdentityRole();
                rol.Name = RoleName;
                roleManager.Create(rol);
            }
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var lstUserVm = new List<UserViewModel>();

            foreach (var user in userManager.Users)
            {
                var userVm = new UserViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email
                };
                lstUserVm.Add(userVm);
            }
            return View("Index", lstUserVm);
        }

        public ActionResult EliminateRole()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }

        public ActionResult DeleteRolSystem(string RoleName)
        {
            try
            {
                var thisRole = db.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                db.Roles.Remove(thisRole);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("EliminateRole");
            }          
            return RedirectToAction("Index");
        }
    }      
}