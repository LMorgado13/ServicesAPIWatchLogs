using WatchDog.Application.DTO;
using WatchDog.Transversal.Common;

namespace WatchDog.Application.Interface
{
    public interface IUsersApplication
    {
        ResponseGeneric<UsersDto> Authenticate(string username, string password);
    }
}
