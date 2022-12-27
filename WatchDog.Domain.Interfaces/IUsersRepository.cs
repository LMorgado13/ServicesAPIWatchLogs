using WatchDog.Domain.Entity;
using WatchDog.Infrastructure.Interface;

namespace WatchDog.Domain.Interfaces
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username, string password);
    }
}
