using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface IWorkedHourRepository
    {
        Task Save(ProjectWorkedHour workedHour);
        Task<ProjectWorkedHour> Get(long id);
        Task<IList<ProjectWorkedHour>> GetByProject(long id);
        Task<IList<ProjectWorkedHour>> GetByEmployee(long id, long projectId);
        Task<IList<ProjectWorkedHour>> Report(DateTime startDate, DateTime endDate, long projectId, long teamId, long employeeId);
    }
}
