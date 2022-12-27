using WatchDog.Domain.Entity;

namespace WatchDog.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {

        Users Authenticate(string username, string password);
    }
}
