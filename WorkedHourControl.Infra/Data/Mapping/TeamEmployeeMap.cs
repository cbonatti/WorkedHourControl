using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class TeamEmployeeMap : EntityBaseMap<TeamEmployee>
    {
        public override void Configure(EntityTypeBuilder<TeamEmployee> builder)
        {
            base.Configure(builder);
            builder
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.Teams)
                .HasForeignKey(bc => bc.EmployeeId);
        }
    }
}
