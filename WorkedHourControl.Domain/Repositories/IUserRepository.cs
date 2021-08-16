using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Save(User user);
        Task<User> Login(string username, string password);
        Task<User> Get(string username);
        Task<User> Get(long id);
        Task Delete(long id);
    }
}
