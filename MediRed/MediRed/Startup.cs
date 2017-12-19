using MediRed.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediRed.Startup))]
namespace MediRed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Se crea un administrador y un usuario por defecto
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    // Primero creamos el rol administrador
            //    var role = new IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    //Se crea el superusuario		

            //    var user = new ApplicationUser();
            //    user.UserName = " SuperUsuario";
            //    user.Id = "ecmcaceres@gmail.com";
            //    string userPWD = "Eve666.";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //se agrega el rol administrador al superusuario
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");
            //    }
            //}

            // Se crea el Perfil de Médico
            if (!roleManager.RoleExists("Médico"))
            {
                var role = new IdentityRole();
                role.Name = "Médico";
                roleManager.Create(role);
            }
            // Se crea el Rol de Paciente
            if (!roleManager.RoleExists("Paciente"))
            {
                var role = new IdentityRole();
                role.Name = "Paciente";
                roleManager.Create(role);
            }
        }
    }
}

