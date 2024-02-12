using System.Diagnostics;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<LibraryContext>(options =>
                    options.UseSqlite("Data Source=/Users/Noa/Documents/GitHub/donde-esta-la-biblioteca/ressources/library.db"));
        builder.Services.AddScoped<ICatalogManager, CatalogManager>();
        builder.Services.AddScoped<ICatalogService, CatalogService>();
        builder.Services.AddScoped<IGenericRepository<Book>, BookRepository>();
        builder.Services.AddScoped<IGenericRepository<Author>, AuthorRepository>();
        builder.Services.AddScoped<IGenericRepository<Library>, LibraryRepository>();
        /*
        Les Middleware ajoutés avant le builder seront récupérer par l'application
        */

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}