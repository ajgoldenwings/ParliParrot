using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence.EntityConfigurations;

namespace WebAPI.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationRole> OrganizationRoles { get; set; }
        public DbSet<UserOrganizationRole> UserOrganizationRoles { get; set; }
        public DbSet<MembershipRequest> MembershipRequests { get; set; }
        //public DbSet<Motion> Motions { get; set; }
        //public DbSet<Vote> Votes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Organization>().ToTable("Organizations");
            builder.Entity<OrganizationRole>().ToTable("OrganizationRoles");
            builder.Entity<UserOrganizationRole>().ToTable("UserOrganizationRoles");
            builder.Entity<MembershipRequest>().ToTable("MembershipRequests");
            //builder.Entity<Motion>().ToTable("Motions");
            //builder.Entity<Vote>().ToTable("Votes");

            builder.ApplyConfiguration(new OrganizationConfiguration());
            builder.ApplyConfiguration(new OrganizationRoleConfiguration());
            builder.ApplyConfiguration(new UserOrganizationRoleConfiguration());
            builder.ApplyConfiguration(new MembershipRequestConfiguration());
            //builder.ApplyConfiguration(new MotionConfiguration());
            //builder.ApplyConfiguration(new VoteConfiguration());
        }
    }
}
