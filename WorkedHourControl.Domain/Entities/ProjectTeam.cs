using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class ProjectTeam : EntityBase
    {
        public ProjectTeam()
        {
        }

        public ProjectTeam(long teamId)
        {
            TeamId = teamId;
        }

        public long ProjectId { get; private set; }
        public virtual Project Project { get; private set; }
        public long TeamId { get; private set; }
        public virtual Team Team { get; private set; }
    }
}
