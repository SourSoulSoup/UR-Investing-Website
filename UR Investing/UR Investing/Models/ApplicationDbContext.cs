using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace UR_Investing.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<UR_Investing.Models.Member> Members { get; set;} 

        public System.Data.Entity.DbSet<UR_Investing.Models.Team> Teams { get; set; }

        public System.Data.Entity.DbSet<UR_Investing.Models.Position> Positions { get; set; }
    }
}