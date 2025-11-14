using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BeeBuzz.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>()
                .HasMany(t => t.Users).WithOne(r => r.Organization)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ApplicationUser>()
            //.HasOne(t => t.Users).WithOne(r => r.Organization)
            //.OnDelete(DeleteBehavior.Cascade);

            //RAN OUT OF TIME
        }
    }
}
