using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkedHourContext _context;

        public UserRepository(WorkedHourContext context)
        {
            _context = context;
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Get(string username) => await _context.Users.SingleOrDefaultAsync(x => x.Username == username);

        public async Task<User> Get(long id) => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IList<User>> Get() => await _context.Users.ToListAsync();

        public async Task<User> Login(string username, string password) 
            => await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

        public async Task Save(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
