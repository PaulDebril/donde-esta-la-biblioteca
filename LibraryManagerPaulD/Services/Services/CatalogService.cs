using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using System.Collections.Generic;

namespace Services.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogManager _catalogManager;

        public CatalogService(ICatalogManager bookRepository)
        {
            _catalogManager = bookRepository;
        }

        public IEnumerable<Book> ShowCatalog()
        {
            return _catalogManager.DisplayCatalog();
        }

        public IEnumerable<Book> ShowCatalog(string type)
        {
            return _catalogManager.DisplayCatalog(type);
        }

        public Book FindBook(int id)
        {
            return _catalogManager.FindBook(id);
        }


        public IEnumerable<Book> DisplayFantasyBooks()
        {
            return _catalogManager.DisplayFantasyBooks();
        }

        public Book GetTopRatedBook()
        {
            return _catalogManager.GetTopRatedBook();
        }

        public Book AddBook(Book book)
        {
            return _catalogManager.AddBook(book);
        }

        public Book UpdateBook(Book book)
        {
            return _catalogManager.UpdateBook(book);
        }

        public Book DeleteBook(int id)
        {
            return _catalogManager.DeleteBook(id);
        }
    }
}
