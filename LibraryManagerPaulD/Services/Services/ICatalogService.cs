using BusinessObjects.Entity;

namespace Services.Services
{
    public interface ICatalogService
    {
        IEnumerable<Book> DisplayFantasyBooks();
        Book FindBook(int id);
        Book GetTopRatedBook();
        IEnumerable<Book> ShowCatalog();
        IEnumerable<Book> ShowCatalog(string type);
    }
}