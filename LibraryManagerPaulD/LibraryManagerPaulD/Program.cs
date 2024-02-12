using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;

class Program
{
    static void Main(string[] args)
    {

        var host = CreateHostBuilder();
        var service = host.Services.GetRequiredService<ICatalogService>();
        service.ShowCatalog();


        Console.WriteLine($"Livres fantasy:");

        var fantasyBooks = service.DisplayFantasyBooks();
        // Traiter et afficher les résultats
        foreach (var book in fantasyBooks)
        {
            Console.WriteLine($"Book Name: {book.Name}");
        }


        Console.WriteLine($"Livre le mieux noté:");

        var topRatedBook = service.GetTopRatedBook();
        Console.WriteLine($"Book Name: {topRatedBook.Name}");
    }

    private static IHost CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddDbContext<LibraryContext>(options =>
                    options.UseSqlite("Data Source=/Users/paul/Documents/GitHub/donde-esta-la-biblioteca/ressources/library.db"));
                services.AddScoped<ICatalogManager, CatalogManager>();
                services.AddScoped<ICatalogService, CatalogService>();
                services.AddScoped<IGenericRepository<Book>, BookRepository>();
                services.AddScoped<IGenericRepository<Author>, AuthorRepository>();
                services.AddScoped<IGenericRepository<Library>, LibraryRepository>();
            })
            .Build();
    }
}
