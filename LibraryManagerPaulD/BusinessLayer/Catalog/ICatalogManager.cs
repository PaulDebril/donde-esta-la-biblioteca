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
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(int id);
    }
}