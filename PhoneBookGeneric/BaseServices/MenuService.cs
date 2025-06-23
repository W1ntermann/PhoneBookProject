using PhoneBookGeneric.Models;

namespace PhoneBookGeneric.BaseServices;

public class MenuService
{
    private readonly PhoneBook<Subscriber> _book;

    public MenuService(PhoneBook<Subscriber> book)
    {
        _book = book;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати абонента");
            Console.WriteLine("2. Вивести всіх");
            Console.WriteLine("3. Пошук за містом");
            Console.WriteLine("4. Видалити абонента за ім’ям");
            Console.WriteLine("0. Вихід");
            Console.Write("Вибір: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    var subscriber = new Subscriber();
                    Console.Write("Ім’я: ");
                    subscriber.Name = Console.ReadLine();
                    Console.Write("Телефон: ");
                    subscriber.PhoneNumber = Console.ReadLine();
                    Console.Write("Місто: ");
                    subscriber.City = Console.ReadLine();
                    _book.AddSubscriber(subscriber);
                    break;
                case "2":
                    _book.Get();
                    break;
                case "3":
                    Console.Write("Введіть місто: ");
                    var city = Console.ReadLine();
                    _book.DisplayByCity(city);
                    break;
                case "4":
                    Console.Write("Введіть ім’я: ");
                    var name = Console.ReadLine();
                    _book.Remove(name);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невідомий вибір.");
                    break;
            }
        }
    }
}