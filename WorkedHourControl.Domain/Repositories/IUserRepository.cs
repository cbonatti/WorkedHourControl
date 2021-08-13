using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Save(User user);
        Task<User> Login(string username, string password);
    }
}
