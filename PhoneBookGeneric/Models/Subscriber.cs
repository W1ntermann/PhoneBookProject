namespace PhoneBookGeneric.Models;

public class Subscriber
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Name}, {PhoneNumber}, {City}, {Country}";
    }
}