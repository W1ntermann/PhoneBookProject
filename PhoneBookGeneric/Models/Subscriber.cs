namespace PhoneBookGeneric.Models;

public class Subscriber
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"{Name}, {PhoneNumber}, {City}, {Country}";
    }
}