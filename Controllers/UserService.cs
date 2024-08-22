using ApiMarvel.Data;
using ApiMarvel.Repository;

namespace ApiMarvel.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}
