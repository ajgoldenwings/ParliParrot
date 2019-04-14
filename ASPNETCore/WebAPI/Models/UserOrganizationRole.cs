using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserOrganizationRole
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public Organization Organization { get; set; }

        public int OrganizationId { get; set; }

        public OrganizationRole Role { get; set; }

        public int RoleId { get; set; }
    }
}