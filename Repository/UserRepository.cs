using ApiMarvel.Data;
using ApiMarvel.Model;

namespace ApiMarvel.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly BDComicsContext ComicsContext;
        public UserRepository(BDComicsContext ComicsContext) : base(ComicsContext)
        {
            this.ComicsContext = ComicsContext;
        }

        public Task<bool> CheckAccount(UserDto userDto)
        {
            bool rpta = true;
            try
            {
                var existingUser = ComicsContext.Users
                    .FirstOrDefault(u => u.Email == userDto.Email && u.Password == userDto.Password);
                if (existingUser == null)
                    rpta = false;
            }
            catch (Exception ex)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);
        }
    }
}
