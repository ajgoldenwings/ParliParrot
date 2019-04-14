using WebAPI.Models;
using WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Persistence;

namespace WebAPI.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private IApplicationDbContext _context;

        public OrganizationRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Organization organization)
        {
            _context.Organizations.Add(organization);
        }

        // Returns a lis of organizations<organization, isMember, hasRequested>
        public IEnumerable<Tuple<Organization, bool, bool>> GetUserOrganizationRolesByQuery(string query, string userId)
        {
            var queryToUpper = query.ToUpper();

            var queryResult = (
                from organizations in _context.Organizations
                    .Where(o => o.Name.ToUpper().Contains(queryToUpper)
                        || o.Identifier.ToUpper().Contains(queryToUpper))
                from userOrganizationRoles in _context.UserOrganizationRoles
                    .Where(u => u.OrganizationId == organizations.Id && u.UserId == userId)
                    .DefaultIfEmpty() // <== makes join left join
                from membershipRequest in _context.MembershipRequests
                    .Where(m => m.OrganizationId == organizations.Id && m.UserId == userId)
                    .DefaultIfEmpty() // <== makes join left join

                select new Tuple<Organization, bool, bool>(organizations, userOrganizationRoles != null, membershipRequest != null) 
            ).AsEnumerable();

            return queryResult;
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            return _context.Organizations;
        }

        public Organization GetOrganizationByIdentifier(string identifier)
        {
            return _context.Organizations
                .SingleOrDefault(o => o.Identifier.ToUpper() == identifier.ToUpper());
        }

        public bool CheckIdentifierNotDuplicate(string alphaOnly)
        {
            bool noDuplicate = false;

            var organization = GetOrganizationByIdentifier(alphaOnly);

            if (organization == null)
                noDuplicate = true;

            return noDuplicate;
        }
    }
}
