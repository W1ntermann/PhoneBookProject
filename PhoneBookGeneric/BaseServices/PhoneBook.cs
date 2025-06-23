using PhoneBookGeneric.Models;
using PhoneBookGeneric.Repositories;

namespace PhoneBookGeneric.BaseServices;

public class PhoneBook<T> where T : Subscriber
{
    private readonly IRepository<T> _repository;
    private readonly ILogger _logger;

    public PhoneBook(IRepository<T> repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void AddSubscriber(T subscriber)
    {
        _repository.Add(subscriber);
        _logger.Log("New Sub Has Been Added !");
    }

    public void DisplayByCity(string? city)
    {
        var filtered = _repository.Find(s => s.City == city);

        var subscribers = filtered.ToList();
        if (!subscribers.Any())
        {
            _logger.Log($"There are no subscribers in that city {city}");
            return;
        }
        
        foreach (var subscriber in subscribers)
        {
            Console.WriteLine(subscriber);
        }
    }

    public void Get()
    {
        var subscribers = _repository.GetAll();

        foreach (var subscriber in subscribers)
        {
            Console.WriteLine(subscriber);
        }
    }
    
    public void Remove(string? name)
    {
        _repository.Remove(s => s.Name == name);
        _logger.Log($"Subscriber by {name} has been removed");
    }
}