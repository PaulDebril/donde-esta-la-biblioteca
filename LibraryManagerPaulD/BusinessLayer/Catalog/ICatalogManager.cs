using BusinessObjects.Entity;

namespace BusinessLayer.Catalog
{
    public interface ICatalogManager
    {
        IEnumerable<Book> DisplayCatalog();
        IEnumerable<Book> DisplayCatalog(string type);
        IEnumerable<Book> DisplayFantasyBooks();
        Book FindBook(int id);
        Book GetTopRatedBook();
    }
}