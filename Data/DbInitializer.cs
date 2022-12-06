using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JanGym.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void Initalize()
        {
            try
            {
                if (db.Database.GetPendingMigrations().Count() > 0)
                {
                    db.Database.Migrate();
                }


            }
            catch
            {

            }

           

            if (db.Roles.Any(x => x.Name == "Admin")) return;

            roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();

            var res = userManager.CreateAsync(new IdentityUser
            {
                UserName = "abdo",
                Email = "abdo@gmail.com",
                EmailConfirmed = true
            }, "Aa123!@#").GetAwaiter().GetResult();




            IdentityUser user = db.Users.FirstOrDefault(u => u.Email == "abdo@gmail.com");
            userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();


        }
    }
}
