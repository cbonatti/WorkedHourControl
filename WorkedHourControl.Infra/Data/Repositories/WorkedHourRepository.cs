using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Infra.Data.Repositories
{
    public class WorkedHourRepository : IWorkedHourRepository
    {
        private readonly WorkedHourContext _context;

        public WorkedHourRepository(WorkedHourContext context)
        {
            _context = context;
        }

        public async Task<ProjectWorkedHour> Get(long id) => await _context.WorkedHour.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<ProjectWorkedHour>> GetByEmployee(long id, long projectId) => await _context.WorkedHour.Where(x => x.EmployeeId == id && x.ProjectId == projectId).ToListAsync();

        public async Task<IList<ProjectWorkedHour>> GetByProject(long id) => await _context.WorkedHour.Where(x => x.ProjectId == id).ToListAsync();

        public async Task<IList<ProjectWorkedHour>> Report(DateTime startDate, DateTime endDate, long projectId, long teamId, long employeeId)
        {
            var query = _context.WorkedHour.Where(x => x.Date >= startDate && x.Date <= endDate && x.ProjectId == projectId);
            if (teamId > 0)
                query = query.Where(x => x.TeamId == teamId);
            if (employeeId > 0)
                query = query.Where(x => x.EmployeeId == employeeId);
            return await query.ToListAsync();
        }

        public async Task Save(ProjectWorkedHour workedHour)
        {
            if (workedHour.Id == 0)
                _context.WorkedHour.Add(workedHour);
            else
                _context.WorkedHour.Update(workedHour);
            await _context.SaveChangesAsync();
        }
    }
}
