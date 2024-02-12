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

    public Book Insert(Book book)
    {
        _context.Book.Add(book);
        _context.SaveChanges();
        return book;
    }

    public Book Update(Book book)
    {
        _context.Book.Update(book);
        _context.SaveChanges();
        return book;
    }

    public Book Delete(int id)
    {
        var book = _context.Book.First(x => x.Id == id);
        _context.Book.Remove(book);
        _context.SaveChanges();
        return book;
    }



}
