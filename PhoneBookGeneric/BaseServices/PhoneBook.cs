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

    public async Task AddSubscriberAsync(T subscriber)
    {
        await _repository.Add(subscriber);
        _logger.Log("New Sub Has Been Added !");
    }

    public async Task DisplayByCity(string? city)
    {
        var subscribers = (await _repository.FindAsync(s => s.City == city)).ToList();

        if (!subscribers.Any())
        {
            _logger.Log($"There are no subscribers in city: {city}");
            return;
        }

        foreach (var subscriber in subscribers)
        {
            Console.WriteLine(subscriber);
        }
    }

    public async Task Get()
    {
        _logger.Log("Getting subscriber....s");

        var subscribers = await _repository.GetAllAsync();

        foreach (var subscriber in subscribers)
        {
            Console.WriteLine(subscriber);
        }

    }
    
    public async Task RemoveAsync(string? name)
    {
        await _repository.RemoveAsync(s => s.Name == name);
        _logger.Log($"Subscriber by {name} has been removed");
    }
}