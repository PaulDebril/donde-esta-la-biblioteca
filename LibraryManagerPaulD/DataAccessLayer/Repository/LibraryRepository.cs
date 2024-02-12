using System.Linq;
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
}
