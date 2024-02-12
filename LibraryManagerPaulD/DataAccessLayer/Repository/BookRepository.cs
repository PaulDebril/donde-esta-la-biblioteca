using BusinessObjects.Entity;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;

public class BookRepository : IGenericRepository<Book>
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Book.ToList();
    }

    public Book Get(int id)
    {
        return _context.Book.Find(id);
    }
}
