using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Persistence;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserOrganizationRoleRepository : IUserOrganizationRoleRepository
    {
        private IApplicationDbContext _context;

        public UserOrganizationRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(UserOrganizationRole userOrganizationRole)
        {
            _context.UserOrganizationRoles.Add(userOrganizationRole);
        }

        public UserOrganizationRole GetUserOrganizationRole(string userId, string organizationIdentifier)
        {
            return _context.UserOrganizationRoles
                .Include(o => o.Organization)
                .Include(r => r.Role)
                .SingleOrDefault(a => a.User.Id == userId && a.Organization.Identifier == organizationIdentifier);
        }

        public IEnumerable<UserOrganizationRole> GetUserOrganizationRoles(string userId)
        {
            return _context.UserOrganizationRoles
                .Include(a => a.Organization)
                .Include(a => a.Role)
                .Where(a => a.User.Id == userId)
                .ToList();
        }
    }
}
