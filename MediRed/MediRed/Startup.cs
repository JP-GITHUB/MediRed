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

            // Se crea el Perfil de Médico
            if (!roleManager.RoleExists("Medico"))
            {
                var role = new IdentityRole();
                role.Name = "Medico";
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

