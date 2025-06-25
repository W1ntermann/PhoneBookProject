using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PhoneBookGeneric.Models;

namespace PhoneBookGeneric.Repositories;

public class DataBaseRepository<T> : IRepository<T> where T : class
{
    private readonly SubsDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public DataBaseRepository(SubsDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task Add(T item)
    {
        await _dbSet.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet
            .Where(predicate)
            .ToListAsync();
    }

    public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
    {
        var items = await _dbSet.Where(predicate).ToListAsync();
        _dbSet.RemoveRange(items);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update)
    {
        return await _dbSet
            .Where(predicate)
            .ExecuteUpdateAsync(update);
    }
}