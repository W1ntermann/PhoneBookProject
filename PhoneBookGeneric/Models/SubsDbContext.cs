using Microsoft.EntityFrameworkCore;

namespace PhoneBookGeneric.Models;

public class SubsDbContext : DbContext
{
    public DbSet<Subscriber>? Subscribers { get; set; }

    public SubsDbContext(DbContextOptions<SubsDbContext> options) 
    : base(options)
    {
    }
}