using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping.Base;

namespace WorkedHourControl.Infra.Data.Mapping
{
    public class ProjectTeamMap : EntityBaseMap<ProjectTeam>
    {
        public override void Configure(EntityTypeBuilder<ProjectTeam> builder)
        {
            base.Configure(builder);
            builder
                 .HasOne(bc => bc.Team)
                 .WithMany(b => b.Projects)
                 .HasForeignKey(bc => bc.TeamId);
            builder
                .HasOne(bc => bc.Project)
                .WithMany(b => b.Teams)
                .HasForeignKey(bc => bc.ProjectId);
        }
    }
}
