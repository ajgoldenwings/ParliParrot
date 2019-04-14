using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Persistence.EntityConfigurations
{
    public class UserOrganizationRoleConfiguration : IEntityTypeConfiguration<UserOrganizationRole>
    {
        public void Configure(EntityTypeBuilder<UserOrganizationRole> builder)
        {
            builder.Property(u => u.UserId)
                .IsRequired();

            builder.Property(u => u.OrganizationId)
                .IsRequired();

            builder.Property(u => u.RoleId)
                .IsRequired();
        }
    }
}
