using MoqTestDemoApp.Data;
using System.Linq.Expressions;
using MoqTestDemoApp.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MoqTestDemoApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext dbContext;
        protected readonly DbSet<TEntity> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.SelectAsync(expression);

            if (entity is not null)
            {
                return true;
            }

            return false;
        }

        public bool DeleteMany(Expression<Func<TEntity, bool>> expression)
        {
            var entities = dbSet.Where(expression);
            if (entities.Any())
            {
                foreach (var entity in entities)

                    return true;
            }

            return false;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = await this.dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entry.Entity;
        }

        public async ValueTask<bool> InsertAsync(IEnumerable<TEntity> entity)
        {
            await this.dbSet.AddRangeAsync(entity);
            return true;
        }

        public async ValueTask SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
        {
            IQueryable<TEntity> query = expression is null ? this.dbSet : this.dbSet.Where(expression);

            if (includes is not null)
            {
                foreach (string include in includes)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
            => await this.SelectAll(expression).FirstOrDefaultAsync(expression);

        public TEntity Update(TEntity entity)
        {
            EntityEntry<TEntity> entryentity = this.dbContext.Update(entity);
            dbContext.SaveChangesAsync();
            return entryentity.Entity;
        }
    }
}
