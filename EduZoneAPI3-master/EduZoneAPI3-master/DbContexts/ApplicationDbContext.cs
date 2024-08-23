using EduZoneAPI3.Model.ApplicationForm;
using EduZoneAPI3.Model.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduZoneAPI3.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
       /* protected readonly IConfiguration Configuration;

        public UsersDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("EduZoneConString"));
        }*/
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> UsersDetails { get; set; }
        public DbSet<ApplicationForm> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            List<IdentityRole> roles = new List<IdentityRole> { 
            
            
            new IdentityRole{
                
                Name = "Admin", 
                NormalizedName = "ADMIN"           
            
            },
            new IdentityRole{

                Name = "User",
                NormalizedName = "USER"

            }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
