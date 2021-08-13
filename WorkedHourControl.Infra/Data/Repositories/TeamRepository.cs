using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Infra.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly WorkedHourContext _context;

        public TeamRepository(WorkedHourContext context)
        {
            _context = context;
        }

        public async Task<Team> Get(long id) => await _context.Teams.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<Team>> Get() => await _context.Teams.ToListAsync();

        public async Task Save(Team team)
        {
            if (team.Id == 0)
                await _context.Teams.AddAsync(team);
            else
                _context.Teams.Update(team);
        }
    }
}
