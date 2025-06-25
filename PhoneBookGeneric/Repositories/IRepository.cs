using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace PhoneBookGeneric.Repositories;

public interface IRepository<T> where T : class
{
    Task Add(T item);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task RemoveAsync(Expression<Func<T, bool>> predicate);
    Task<int> UpdateAsync(
        Expression<Func<T, bool>> predicate,
        Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> update);

}