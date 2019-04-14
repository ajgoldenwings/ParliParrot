using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IOrganizationRoleRepository
    {
        int getMemberId();
        int getOwnerId();
    }
}
