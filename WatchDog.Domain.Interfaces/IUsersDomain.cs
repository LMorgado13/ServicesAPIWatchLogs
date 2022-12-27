using WatchDog.Domain.Entity;

namespace WatchDog.Domain.Interfaces
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
