using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JanGym.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {
        }

        public DbSet<TraineeInfoModel> RegisterNewTraineeModel { get; set; }
        public DbSet<SubscribeModel> SubscribeModel { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

    }
}

