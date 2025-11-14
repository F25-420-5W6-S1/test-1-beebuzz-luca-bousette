using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        [Required]
        public int OrganizationId { get; set; }

        public virtual ICollection<Beehive> Beehives { get; set; } = new List<Beehive>();
        public virtual Organization Organization { get; set; } = new Organization();
    }
}
