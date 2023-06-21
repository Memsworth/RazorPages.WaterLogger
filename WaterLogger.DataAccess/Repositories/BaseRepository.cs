using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WaterLogger.Domain.Abstraction.Repositories;

namespace WaterLogger.DataAccess.Repositories;


public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly WaterLoggerDbContext WaterLoggerDbContext;
    public BaseRepository(WaterLoggerDbContext dbContext) => WaterLoggerDbContext = dbContext;
    
    //TODO: DO THIS OR ELSE
    public async Task<IQueryable<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
         WaterLoggerDbContext.Set<T>().Where(predicate).AsQueryable();

    public async Task<IEnumerable<T>> GetAsync() => await WaterLoggerDbContext.Set<T>().ToListAsync();

    public async Task<T> GetAsync(int id)
    {
        var item = await WaterLoggerDbContext.Set<T>().FindAsync(id);
        if (item is null)
        {
            throw new KeyNotFoundException();
        }

        return item;
    }

    public async Task AddAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        await WaterLoggerDbContext.AddAsync(entity);
    }

    public async Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}