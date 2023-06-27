using System.Linq.Expressions;
using WaterLogger.Domain.Models;

namespace WaterLogger.Domain.Abstraction.Repositories;

public interface IBaseRepository<T> where T : DbBaseModel
{ 
    Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAsync();
    Task<T?> GetAsync(int id);
    Task AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
}
