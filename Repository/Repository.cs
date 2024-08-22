using ApiMarvel.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiMarvel.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly BDComicsContext ComicsContext;

        public Repository(BDComicsContext ComicsContext)
        {
            this.ComicsContext = ComicsContext;
        }


        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("The entity is null");
            }

            ComicsContext.Set<TEntity>().Remove(entity);
            await ComicsContext.SaveChangesAsync();
        }

       
        public async Task<TEntity> GetById(int id)
        {
            return await ComicsContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetList()
        {
            return await ComicsContext.Set<TEntity>().ToListAsync();
        }
              

        public async Task<TEntity> Insert(TEntity entity)
        {
            await ComicsContext.Set<TEntity>().AddAsync(entity);
            await ComicsContext.SaveChangesAsync();
            return entity;
        }

      
        public async Task<TEntity> Update(TEntity entity)
        {
            ComicsContext.Set<TEntity>().Update(entity);
            await ComicsContext.SaveChangesAsync();
            return entity;
        }
    }
}
