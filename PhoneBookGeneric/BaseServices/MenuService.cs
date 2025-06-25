using PhoneBookGeneric.Models;

namespace PhoneBookGeneric.BaseServices;

public class MenuService
{
    private readonly PhoneBook<Subscriber> _book;

    public MenuService(PhoneBook<Subscriber> book)
    {
        _book = book;
    }

    public async Task Start()
    {
        
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add new Subscriber");
            Console.WriteLine("2. Get All Subscribers");
            Console.WriteLine("3. Search by city");
            Console.WriteLine("4. Delete Subscriber by name");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    var subscriber = new Subscriber();
                    Console.Write("Name: ");
                    subscriber.Name = Console.ReadLine();
                    Console.Write("Phone: ");
                    subscriber.PhoneNumber = Console.ReadLine();
                    Console.Write("City: ");
                    subscriber.City = Console.ReadLine();
                    await _book.AddSubscriberAsync(subscriber);
                    break;
                case "2":
                    await _book.Get();
                    break;
                case "3":
                    Console.Write("Enter city: ");
                    var city = Console.ReadLine();
                    await _book.DisplayByCity(city);
                    break;
                case "4":
                    Console.Write("Enter name: ");
                    var name = Console.ReadLine();
                   await _book.RemoveAsync(name);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Unknown choice.");
                    break;
            }
        }
    }
}