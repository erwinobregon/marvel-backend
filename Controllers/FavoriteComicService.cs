using ApiMarvel.Data;
using ApiMarvel.Repository;

namespace ApiMarvel.Services
{
    public class FavoriteComicService : Service<FavoriteComic>, IFavoriteComicService
    {
        public FavoriteComicService(IFavoriteComicRepository repository) : base(repository)
        {
        }
    }
}
