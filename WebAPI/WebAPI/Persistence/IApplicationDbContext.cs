using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Organization> Organizations { get; set; }
        DbSet<OrganizationRole> OrganizationRoles { get; set; }
        DbSet<UserOrganizationRole> UserOrganizationRoles { get; set; }
        DbSet<MembershipRequest> MembershipRequests { get; set; }

        //DbSet<Motion> Motions { get; set; }
        //DbSet<Vote> Votes { get; set; }
    }
}
