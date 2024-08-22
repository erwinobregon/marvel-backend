using ApiMarvel.Data;

namespace ApiMarvel.Repository
{
    public class FavoriteComicRepository : Repository<FavoriteComic>, IFavoriteComicRepository
    {
        public FavoriteComicRepository(BDComicsContext ComicsContext) : base(ComicsContext)
        {
        }
    }
}
