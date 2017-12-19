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
        }

        // En este métoso se crearán los roles por defecto de los usuarios y un usuario administrador que sea superusurio
        private void CreateRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Se crea primero el rol de administrador y un usuario por defecto que tenga este rol 
            if (!roleManager.RoleExists("Admin"))
            {
                // primero se crea el rol de administrador
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //se crea el superusuario para asignarle el rol de administrador

                var user = new ApplicationUser();
                user.Id = "ecmcaceres@gmail.com";
                user.UserName = "Admin";             

                string userPWD = "Aiep2017,";

                var chkUser = UserManager.Create(user, userPWD);

                //se crea el usuario por defecto que tenga el rol de administrador
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // se crea el rol de médico
            if (!roleManager.RoleExists("Médico"))
            {
                var role = new IdentityRole();
                role.Name = "Médico";
                roleManager.Create(role);
            }

            // se crea el rol de paciente
            if (!roleManager.RoleExists("Paciente"))
            {
                var role = new IdentityRole();
                role.Name = "Paciente";
                roleManager.Create(role);
            }
        }
    }
}

