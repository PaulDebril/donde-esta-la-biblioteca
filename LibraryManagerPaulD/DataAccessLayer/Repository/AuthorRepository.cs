using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Entity;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository : IGenericRepository<Author>
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author Get(int id_author)
        {
            return _context.Authors.Find(id_author) ?? new Author();
        }
    }
}
