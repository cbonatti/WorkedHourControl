using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class ProjectWorkedHourMap : EntityBaseMap<ProjectWorkedHour>
    {
        public override void Configure(EntityTypeBuilder<ProjectWorkedHour> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.TimeSpent).IsRequired();
            builder
                .HasOne(bc => bc.Project)
                .WithMany(b => b.WorkedHours)
                .HasForeignKey(bc => bc.ProjectId);
        }
    }
}
