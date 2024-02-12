using DataAccessLayer.Repository;
using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Catalog
{
    public class CatalogManager : ICatalogManager
    {
        private readonly IGenericRepository<Book> _GenericRepository;
        
        public CatalogManager(IGenericRepository<Book> genericRepository)
        {
            _GenericRepository = genericRepository;
        }

        public IEnumerable<Book> DisplayCatalog()
        {
            return _GenericRepository.GetAll();
        }

        public IEnumerable<Book> DisplayCatalog(string type)
        {
            if (Enum.TryParse(type, true, out BookType parsedType))
            {
                return _GenericRepository.GetAll().Where(book => book.Type == parsedType);
            }
            return Enumerable.Empty<Book>();
        }

        public Book FindBook(int id)
        {
            return _GenericRepository.Get(id);
        }

        public IEnumerable<Book> DisplayFantasyBooks()
        {
            var query = from book in _GenericRepository.GetAll()
                        where book.Type == BookType.Fantasy
                        select book;
            return query;
        }

        public Book GetTopRatedBook()
        {
            var topRatedBook = _GenericRepository.GetAll()
                              .OrderByDescending(book => book.Rate)
                              .FirstOrDefault();
            return topRatedBook;
        }

        public Book AddBook(Book book)
        {
            return _GenericRepository.Insert(book);
        }

        public Book UpdateBook(Book book)
        {
            return _GenericRepository.Update(book);
        }

        public Book DeleteBook(int id)
        {
            return _GenericRepository.Delete(id);
        }

    }
}
