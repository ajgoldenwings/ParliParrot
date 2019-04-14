using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IMembershipRequestRepository
    {
        void Add(MembershipRequest membershipRequest);
        IEnumerable<MembershipRequest> GetMembershipRequestsByOrganizationIdentifier(string identifier);
        MembershipRequest GetMembershipRequestsById(int id);
        void Remove(MembershipRequest membershipRequest);
    }
}
