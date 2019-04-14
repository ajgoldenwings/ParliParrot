using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Persistence;

namespace WebAPI.Repositories
{
    public class MembershipRequestRepository : IMembershipRequestRepository
    {
        private IApplicationDbContext _context;

        public MembershipRequestRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(MembershipRequest membershipRequest)
        {
            _context.MembershipRequests.Add(membershipRequest);
        }

        [Authorize(Policy = "OrganizationRoleIsOwner")]
        public MembershipRequest GetMembershipRequestsById(int id)
        {
            return _context.MembershipRequests
                .Include(m => m.User)
                .SingleOrDefault(m => m.Id == id);
        }

        [Authorize(Policy = "OrganizationRoleIsOwner")]
        public IEnumerable<MembershipRequest> GetMembershipRequestsByOrganizationIdentifier(string identifier)
        {
            return _context.MembershipRequests
                .Include(m => m.User)
                .Where(m => m.Organization.Identifier == identifier)
                .ToList();
        }

        [Authorize(Policy = "OrganizationRoleIsOwner")]
        public void Remove(MembershipRequest membershipRequest)
        {
            _context.MembershipRequests.Remove(membershipRequest);
        }
    }
}
