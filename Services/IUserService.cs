using ApiMarvel.Data;
using ApiMarvel.Model;

namespace ApiMarvel.Services
{
    public interface IUserService : IService<User>
    {
        Task<bool> Register(UserDto userDto);
        Task<bool> Login(UserDto userDto);
    }
}
