using System.Linq.Expressions;

namespace PhoneBookGeneric.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new();

    public Task Add(T item)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Expression<Func<T, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}