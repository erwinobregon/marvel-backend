using ApiMarvel.Data;
using ApiMarvel.Model;
using ApiMarvel.Repository;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;

namespace ApiMarvel.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;


        public UserService(IUserRepository repository, IMapper mapper) : base(repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> Login(UserDto userDto)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] bytePass = Encoding.Default.GetBytes(userDto.Password);
            byte[] byteEncodingPass = sha.ComputeHash(bytePass);
            string encodingPass = BitConverter.ToString(byteEncodingPass).Replace("-","");
            userDto.Password = encodingPass;

            if (await repository.CheckAccount(userDto))
            {

                return true;
            }
            return false;
        }

        public async Task<bool> Register(UserDto userDto)
        {
            SHA256Managed sha = new SHA256Managed();
            byte[] bytePass = Encoding.Default.GetBytes(userDto.Password);
            byte[] byteEncodingPass = sha.ComputeHash(bytePass);
            string encodingPass = BitConverter.ToString(byteEncodingPass).Replace("-", "");
            userDto.Password = encodingPass;

            if (!await repository.CheckAccount(userDto))
            {
                var user = mapper.Map<User>(userDto);
                await repository.Insert(user);
                return true;
            }
            return false;

        }
    }
}
