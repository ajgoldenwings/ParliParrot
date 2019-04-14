using WebAPI.Models;
using System.Collections.Generic;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserOrganizationRoleRepository
    {
        void Add(UserOrganizationRole organization);
        UserOrganizationRole GetUserOrganizationRole(string userId, string organizationIdentifier);
        IEnumerable<UserOrganizationRole> GetUserOrganizationRoles(string userId);
    }
}
