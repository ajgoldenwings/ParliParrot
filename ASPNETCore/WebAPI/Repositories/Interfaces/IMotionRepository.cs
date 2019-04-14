using ParliParrotCore.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParliParrotCore.Core.Repositories
{
    public interface IMotionRepository
    {
        void Add(Motion motion);
        IEnumerable<Motion> GetMotions();
        IQueryable<Motion> GetMotionsByOrganizationIdentifier(string identifier);
        Motion GetMotion(int motionId);
        //IEnumerable<Motion> GetMotionsUserAttending(string userId);
        //Motion GetMotionWithAttendees(int motionId);
        //IEnumerable<Motion> GetUpcomingMotionsByMember(string memberId);
    }
}
