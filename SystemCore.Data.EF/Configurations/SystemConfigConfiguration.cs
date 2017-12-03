using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemCore.Data.EF.Extensions;
using SystemCore.Data.Entities;

namespace SystemCore.Data.EF.Configurations
{
    internal class SystemConfigConfiguration : DbEntityConfiguration<SystemConfig>
    {
        public override void Configure(EntityTypeBuilder<SystemConfig> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(255).IsRequired();
        }
    }
}