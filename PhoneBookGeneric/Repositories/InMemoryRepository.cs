namespace PhoneBookGeneric.Repositories;

public class InMemoryRepository<T> : IRepository<T>
{
    private readonly List<T> _items = new();
    
    public void Add(T item)
    {
        _items.Add(item);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public IEnumerable<T> Find(Func<T, bool> predicate)
    {
        return _items
            .Where(predicate);
    }

    public void Remove(Func<T, bool> predicate)
    {
        _items.RemoveAll(item => predicate(item));
    }
    
}