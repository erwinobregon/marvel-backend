using ApiMarvel.Data;
using ApiMarvel.Repository;

namespace ApiMarvel.Services
{
    public class ComicService : Service<Comic>, IComicService
    {
        public ComicService(IComicRepository repository) : base(repository)
        {
        }
    }
}
