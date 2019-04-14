using WebAPI.Models;
using System;
using System.Collections.Generic;

namespace WebAPI.Repositories.Interfaces
{
    public interface IOrganizationRepository
    {
        void Add(Organization organization);
        Organization GetOrganizationByIdentifier(string alphaOnly);
        bool CheckIdentifierNotDuplicate(string alphaOnly);
        IEnumerable<Organization> GetOrganizations();
        IEnumerable<Tuple<Organization, bool, bool>> GetUserOrganizationRolesByQuery(string query, string userId);
    }
}
