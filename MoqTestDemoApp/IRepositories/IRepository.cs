using System.Linq.Expressions;

namespace MoqTestDemoApp.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> InsertAsync(TEntity entity);
        
        TEntity Update(TEntity entity);
        IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
        ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);      
        ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        bool DeleteMany(Expression<Func<TEntity, bool>> expression);
        
        ValueTask SaveAsync();
    }
}
