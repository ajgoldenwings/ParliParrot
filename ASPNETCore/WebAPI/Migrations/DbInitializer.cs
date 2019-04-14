using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.Migrations
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated(); // if db is not exist, it will create database but do nothing.

            if (!context.OrganizationRoles.Any(o => o.Name == "Owner"))
            {
                var organizationRoles = new List<OrganizationRole>
                {
                    new OrganizationRole { Name = "Owner" },
                };

                foreach (OrganizationRole o in organizationRoles)
                {
                    context.OrganizationRoles.Add(o);
                }
            }

            if (!context.OrganizationRoles.Any(o => o.Name == "Member"))
            {
                var organizationRoles = new List<OrganizationRole>
                {
                    new OrganizationRole { Name = "Member" },
                };

                foreach (OrganizationRole o in organizationRoles)
                {
                    context.OrganizationRoles.Add(o);
                }
            }

            context.SaveChanges();
        }
    }
}
