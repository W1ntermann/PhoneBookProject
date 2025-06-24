using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBookGeneric.BaseServices;
using PhoneBookGeneric.Models;
using PhoneBookGeneric.Repositories;


var configuration = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddScoped<ILogger, ConsoleLogger>();
services.AddScoped<PhoneBook<Subscriber>>();
services.AddScoped<IRepository<Subscriber>, DataBaseRepository<Subscriber>>();
services.AddScoped<MenuService>();

services.AddDbContext<SubsDbContext>(options => 
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

var serviceProvider = services.BuildServiceProvider();

var myService = serviceProvider.GetRequiredService<MenuService>();

await myService.Start();