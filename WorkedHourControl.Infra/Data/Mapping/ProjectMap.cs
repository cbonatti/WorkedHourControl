using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class ProjectMap : EntityBaseMap<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Teams);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
