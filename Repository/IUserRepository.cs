using ApiMarvel.Data;
using ApiMarvel.Model;

namespace ApiMarvel.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        Task<bool> CheckAccount(UserDto userDto);
    }
}
