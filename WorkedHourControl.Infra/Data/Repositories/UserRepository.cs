using Microsoft.EntityFrameworkCore;
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

        public async Task<User> Login(string username, string password) 
            => await _context.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

        public async Task Save(User user)
        {
            if (user.Id == 0)
                await _context.Users.AddAsync(user);
            else
                _context.Users.Update(user);
        }
    }
}
