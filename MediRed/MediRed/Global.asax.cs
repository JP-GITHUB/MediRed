using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using MediRed.Context;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.Routing;
using MediRed.Models;
using System;
using MediRed.Models;
using Microsoft.AspNet.Identity;
using System.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediRed
{
    public class MvcApplication: System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediRedContext, Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSU(db);
            SetRolesSU(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CreateRoles(ApplicationDbContext db)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Antes de crearlo, NO OLVIDAR que primero se debe preguntar si existe el rol

            if (!roleManager.RoleExists("Admin"))
            {
                //Si no existe el rol, se crea
                var role = new IdentityRole() { Name = "Admin" };
                roleManager.Create(role);
            }
        }
        private void CreateSU(ApplicationDbContext db)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            //HL: Primero buscamos el usuario con los datos de las key del webconfig
            var user = UserManager.FindByName(ConfigurationManager.AppSettings["SuperUserName"]);

            //Nota profee HL: si el usuario es vacio lo creamos nuevo pasandole solo en email y nombre de usuario
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    Email = ConfigurationManager.AppSettings["SuperUserName"],
                    UserName = ConfigurationManager.AppSettings["SuperUserName"]

                };

                //Nota profe HL: lo insertamos y le pasamos la pass del WebConfig
                UserManager.Create(user, ConfigurationManager.AppSettings["SuperUserPass"]);
            }    
        }

        private void SetRolesSU(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName(ConfigurationManager.AppSettings["SuperUserName"]);

            //Nota profe HL: Preguntamos si el usuario NO tiene el rol, el rol debe existir previamente
            if (!userManager.IsInRole(user.Id, "Admin"))
            {
                //Nota prof HL: si no esta se lo agregamos
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }        
}