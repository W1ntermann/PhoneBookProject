using PhoneBookGeneric.BaseServices;
using PhoneBookGeneric.Models;
using PhoneBookGeneric.Repositories;

IRepository<Subscriber> repository = new InMemoryRepository<Subscriber>();
ILogger logger = new ConsoleLogger();
PhoneBook<Subscriber> book = new PhoneBook<Subscriber>(repository, logger);

book.AddSubscriber(new Subscriber
{
    Id = 1,
    Name = "Badan",
    LastName = "Badanowycz",
    Country = "Ukraine",
    City = "Odesa",
    PhoneNumber = "380-XXX-XX-XX"
});

book.Get();