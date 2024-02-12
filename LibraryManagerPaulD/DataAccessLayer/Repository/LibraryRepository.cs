using BusinessObjects.Entity;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;

public class LibraryRepository : IGenericRepository<Library>
{
    private readonly LibraryContext _context;

    public LibraryRepository(LibraryContext context)
    {
        _context = context;
    }

    public IEnumerable<Library> GetAll()
    {
        return _context.Libraries.ToList();
    }

    public Library Get(int LibraryId)
    {
        return _context.Libraries.First(x => x.Id == LibraryId);
    }

    Library IGenericRepository<Library>.Get(int TId)
    {
        throw new NotImplementedException();
    }

    IEnumerable<Library> IGenericRepository<Library>.GetAll()
    {
        throw new NotImplementedException();
    }

    Library IGenericRepository<Library>.Insert(Book book)
    {
        throw new NotImplementedException();
    }

    Library IGenericRepository<Library>.Update(Book book)
    {
        throw new NotImplementedException();
    }

    Library IGenericRepository<Library>.Delete(int id)
    {
        throw new NotImplementedException();
    }
}
