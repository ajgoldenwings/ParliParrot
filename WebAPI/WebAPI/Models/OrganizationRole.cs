
namespace WebAPI.Models
{
    public class OrganizationRole
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public bool IsOwner()
        {
            return Name == "Owner";
        }
    }
}
