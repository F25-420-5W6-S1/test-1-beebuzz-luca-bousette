using System.ComponentModel.DataAnnotations;

namespace BeeBuzz.Data.Entities
{
    public class Beehive
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public Status HiveStatus { get; set; }

        [Required]
        public Reason Deactivation {  get; set; }

        public virtual Organization Organization { get; set; } = new Organization();
        public virtual ApplicationUser User { get; set; } = new ApplicationUser();
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public enum Reason
    {
        Dead,
        Sold
    }
}
