using WatchDog.Domain.Entity;
using WatchDog.Domain.Interfaces;
using WatchDog.Infrastructure.Interface;
using IUsersRepository = WatchDog.Infrastructure.Interface.IUsersRepository;

namespace WatchDog.Domain.Cors
{
    public class UsersDomain : IUsersDomain
    {
        private readonly Infrastructure.Interface.IUsersRepository _usersRepository;

        public UsersDomain(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Infrastructure.Interface.IUsersRepository UsersRepository { get; }

        public Users Authenticate(string userName, string password)
        {
            return _usersRepository.Authenticate(userName, password);
        }
    }
}
