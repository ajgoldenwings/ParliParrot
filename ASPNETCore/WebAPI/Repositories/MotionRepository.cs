using Microsoft.EntityFrameworkCore;
using ParliParrotCore.Core.Models;
using ParliParrotCore.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParliParrotCore.Persistence.Repositories
{
    public class MotionRepository : IMotionRepository
    {
        private IApplicationDbContext _context;

        public MotionRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Motion motion)
        {
            _context.Motions.Add(motion);
        }

        public IEnumerable<Motion> GetMotions()
        {
            return _context.Motions
                .Include(m => m.User);
            //.Where(m => m.DateTime > DateTime.Now && !m.IsCanceled);
        }
        
        public IQueryable<Motion> GetMotionsByOrganizationIdentifier(string identifier)
        {
            return _context.Motions
                .Include(m => m.User)
                .Where(m => m.Organization.Identifier == identifier);
        }

        public Motion GetMotion(int motionId)
        {
            return _context.Motions
                .Include(m => m.User)
                .Include(m => m.Organization)
                .SingleOrDefault(m => m.Id == motionId);
        }

        //public Motion GetMotionWithAttendees(int motionId)
        //{
        //    return _context.Motions
        //        .Include(m => m.Attendances.Select(a => a.Attendee))
        //        .SingleOrDefault(m => m.Id == motionId);
        //}

        //public IEnumerable<Motion> GetMotionsUserAttending(string userId)
        //{
        //    return _context.Attendances
        //        .Where(a => a.AttendeeId == userId && a.Motion.DateTime > DateTime.Now)
        //        .Select(a => a.Motion)
        //        .Include(m => m.Member)
        //        .Include(m => m.Type)
        //        .ToList();
        //}

        //public IEnumerable<Motion> GetUpcomingMotionsByMember(string memberId)
        //{
        //    return _context.Motions
        //        .Where(m => m.MemberId == memberId
        //            && m.DateTime > DateTime.Now
        //            && !m.IsCanceled)
        //        .Include(m => m.Type)
        //        .Include(m => m.Member)
        //        .ToList();
        //}
    }
}
