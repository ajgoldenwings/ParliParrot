using ParliParrotCore.Core.Models;
using System;
using System.Linq;

namespace ParliParrotCore.Core.Repositories
{
    public interface IVoteRepository
    {
        void Add(Vote vote);

        Vote GetUserVoteByMotionId(int motionId, string userId);

        IQueryable<Vote> GetVotesByMotionId(int motionId);

        Tuple<int, int, int> GetTotalMembersAgainstFor(Motion motion);
    }
}
