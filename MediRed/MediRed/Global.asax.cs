using System.Data.Entity;
using MediRed.Context;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MediRedContext, MediRed.Migrations.Configuration>());
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
        //Crear superusuario 
        private void CreateSU(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            // Primero se crea el rol de administrador y se crea un usuario admin por defecto
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            //Aqui creamos un administrador con permisos de superusuario      
                var user = new ApplicationUser(); 
                user.Id = "ecmcaceres@gmail.com";
                string userPWD = "Evelyn2017";

                //se crea variable superusuario para agregar en usermanager
                var chkUser = userManager.Create(user, userPWD);

                //se agrega al usuario por defecto el rol de administrador
                 if (chkUser.Succeeded)
                    {
                       var superUser = userManager.AddToRole(user.Id, "Admin");
                    }
                    //Si la creación del usuario es correcta, se agrega rol de administrador a usuario por defecto
                    var result = userManager.AddToRole(user.Id, "Admin");          
            }
        //Setear roles de superusuario
        private void SetRolesSU(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = new ApplicationUser();
            var superUser = userManager.FindByName(ConfigurationManager.AppSettings["SuperUser"]);

            if (!userManager.IsInRole(user.Id, "View"))
            {
                userManager.AddToRole(user.Id, "View");
            }
            if (!userManager.IsInRole(user.Id, "Create"))
            {
                userManager.AddToRole(user.Id, "Create");
            }
            if (!userManager.IsInRole(user.Id, "Edit"))
            {
                userManager.AddToRole(user.Id, "Edit");
            }
            if (!userManager.IsInRole(user.Id, "Delete"))
            {
                userManager.AddToRole(user.Id, "Delete");
            }
        }
          private void CreateRoles(ApplicationDbContext db)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Crear el rol de Médico
            if (!roleManager.RoleExists("Medic"))
            {
                var role = new IdentityRole();
                role.Name = "Medic";
                roleManager.Create(role);
            }
            // Crear el rol de Paciente
            if (!roleManager.RoleExists("Patient"))
            {
                var role = new IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);
            }
        }
    }   
}
