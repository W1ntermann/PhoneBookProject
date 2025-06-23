namespace PhoneBookGeneric.Repositories;

public interface IRepository<T>
{
    void Add(T item);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Func<T, bool> predicate);
    void Remove(Func<T, bool> predicate);
    
}