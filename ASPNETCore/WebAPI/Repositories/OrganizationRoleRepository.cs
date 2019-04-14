using WebAPI.Repositories.Interfaces;
using System.Linq;
using WebAPI.Persistence;

namespace WebAPI.Repositories
{
    public class OrganizationRoleRepository : IOrganizationRoleRepository
    {
        private IApplicationDbContext _context;

        public OrganizationRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        // TODO: create test case
        public int getMemberId()
        {
            var memberId = _context.OrganizationRoles
                .Where(a => a.Name == "Member")
                .Select(a => a.Id)
                .First();

            return memberId;
        }

        // TODO: create test case
        public int getOwnerId()
        {
            var rollId = _context.OrganizationRoles
                .Where(a => a.Name == "Owner")
                .Select(a => a.Id)
                .First();

            return rollId;
        }
    }
}
