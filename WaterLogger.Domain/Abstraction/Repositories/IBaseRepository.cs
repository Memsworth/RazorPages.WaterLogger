using System.Linq.Expressions;

namespace WaterLogger.Domain.Abstraction.Repositories;

public interface IBaseRepository<T> where T : class
{ 
    Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int id);
    Task AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}
