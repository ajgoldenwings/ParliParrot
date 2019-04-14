using Microsoft.EntityFrameworkCore;
using ParliParrotCore.Core.Models;
using ParliParrotCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParliParrotCore.Persistence.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private IApplicationDbContext _context;

        public VoteRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Vote vote)
        {
            _context.Votes.Add(vote);
        }

        public Vote GetUserVoteByMotionId(int motionId, string userId)
        {
            return _context.Votes
                .Include(u => u.User)
                .SingleOrDefault(v => v.MotionId == motionId && v.UserId == userId);
        }

        public IQueryable<Vote> GetVotesByMotionId(int motionId)
        {
            return _context.Votes
                .Where(v => v.MotionId == motionId);
        }

        public Tuple<int, int, int> GetTotalMembersAgainstFor(Motion motion)
        {
            //var users = _context.UserOrganizationRoles.Where(u => u.OrganizationId == motion.OrganizationId).Count();
            //var votesAgainst = _context.Votes.Where(a => a.MotionId == motion.Id && a.VoteFor == false).Count();
            //var votesFor = _context.Votes.Where(f => f.MotionId == motion.Id && f.VoteFor == true).Count();

            //SELECT ISNULL(c.MemberCount, '0') AS MemberCount,
            //    ISNULL(a.MembersAgainst, '0') AS MembersAgainst,
            //    ISNULL(f.MembersFor, '0') AS MembersFor
            //FROM Motions m
            //LEFT JOIN(SELECT COUNT(*) AS MemberCount, u.OrganizationId
            //        FROM UserOrganizationRoles u
            //        WHERE u.OrganizationId = '2'
            //        GROUP BY u.OrganizationId) AS c
            //    ON c.OrganizationId = m.OrganizationId
            //LEFT JOIN(SELECT COUNT(*) AS MembersAgainst, v.MotionId
            //        FROM Votes v
            //        WHERE v.MotionId = '1'
            //            AND v.VoteFor = '0'
            //        GROUP By v.MotionId) a on a.MotionId = m.Id
            //LEFT JOIN(SELECT COUNT(*) AS MembersFor, v.MotionId
            //        FROM Votes v
            //        WHERE v.MotionId = '1'
            //            AND v.VoteFor = '1'
            //        GROUP By v.MotionId) f on f.MotionId = m.Id
            //WHERE m.Id = '1'


            return new Tuple<int, int, int>(
                _context.UserOrganizationRoles.Where(u => u.OrganizationId == motion.OrganizationId).Count(), 
                _context.Votes.Where(a => a.MotionId == motion.Id && a.VoteFor == false).Count(),
                _context.Votes.Where(f => f.MotionId == motion.Id && f.VoteFor == true).Count());
        }

        // Vote Stats

        // people.Join(pets,              // outer sequence
        //  person => person,  // inner sequence key
        //      pet => pet.Owner,  // outer sequence key
        //      (person, pet) =>
        //          new { OwnerName = person.Name, Pet = pet.Name
        //  });

        // We want to return something like:
        //  codes = codesRepo.SearchFor(predicate)
        //    .Select(c => new { c.Id, c.Flag })
        //    .AsEnumerable()
        //    .Select(c => new Tuple<string, byte>(c.Id, c.Flag))
        //    .ToList();
    }
}
