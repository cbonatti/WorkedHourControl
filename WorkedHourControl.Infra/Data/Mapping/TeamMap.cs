using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class TeamMap : EntityBaseMap<Team>
    {
        public override void Configure(EntityTypeBuilder<Team> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Employees);
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
