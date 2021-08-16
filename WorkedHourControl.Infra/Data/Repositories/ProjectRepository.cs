using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Infra.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly WorkedHourContext _context;

        public ProjectRepository(WorkedHourContext context)
        {
            _context = context;
        }

        public async Task<Project> Get(long id) => await _context.Projects.Include(x => x.Teams).ThenInclude(x => x.Team).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Project> GetWithEmployees(long id) => await _context.Projects.Include(x => x.Teams).ThenInclude(x => x.Team).ThenInclude(x=>x.Employees).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<Project>> Get() => await _context.Projects.ToListAsync();

        public async Task Save(Project project)
        {
            if (project.Id == 0)
                _context.Projects.Add(project);
            else
                _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
