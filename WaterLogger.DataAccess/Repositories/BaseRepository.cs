using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WaterLogger.Domain.Abstraction.Repositories;

namespace WaterLogger.DataAccess.Repositories;


public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly WaterLoggerDbContext WaterLoggerDbContext;
    public BaseRepository(WaterLoggerDbContext dbContext) => WaterLoggerDbContext = dbContext;
    
    public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
         await WaterLoggerDbContext.Set<T>().Where(predicate).ToListAsync();

    public async Task<IEnumerable<T>> GetAsync() => await WaterLoggerDbContext.Set<T>().ToListAsync();

    public async Task<T?> GetAsync(int id)
    {
        var item = await WaterLoggerDbContext.Set<T>().FindAsync(id);
        return item ?? null;
    }

    public async Task AddAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        await WaterLoggerDbContext.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        WaterLoggerDbContext.Remove(entity);
    }

    public void Update(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException();
        }

        WaterLoggerDbContext.Update(entity);
    }
}