using System.Linq.Expressions;

namespace PhoneBookGeneric.Repositories;

public interface IRepository<T> where T : class
{
    Task Add(T item);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task RemoveAsync(Expression<Func<T, bool>> predicate);
    
}