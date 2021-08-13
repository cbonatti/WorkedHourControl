using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface ITeamRepository
    {
        Task Save(Team team);
        Task<Team> Get(long id);
        Task<IList<Team>> Get();
    }
}
