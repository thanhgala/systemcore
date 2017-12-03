using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using SystemCore.Data.EF.Extensions;
using SystemCore.Data.Entities;

namespace SystemCore.Data.EF.Configurations
{
    public class PermissionConfiguration : DbEntityConfiguration<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.Property(c => c.FunctionId).IsRequired()
            .HasColumnType("varchar(128)");
            // etc.
        }
    }
}
