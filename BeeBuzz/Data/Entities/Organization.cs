using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BeeBuzz.Data.Entities
{
    public class Organization
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string OrganizationName { get; set; }


        public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
        public virtual ICollection<Beehive> Beehives { get; set; } = new List<Beehive>();
    }
}
