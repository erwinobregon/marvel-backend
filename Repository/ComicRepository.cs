using ApiMarvel.Data;

namespace ApiMarvel.Repository
{
    public class ComicRepository : Repository<Comic>, IComicRepository
    {
        public ComicRepository(BDComicsContext ComicsContext) : base(ComicsContext)
        {
        }
    }
}
