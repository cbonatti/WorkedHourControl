using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task Save(Project project);
        Task<Project> Get(long id);
        Task<IList<Project>> Get();
    }
}
