using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Hosting
{
    [ApiController]
    [Route("[controller]")] 
    public class BookController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;

        public BookController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        // Endpoint pour récupérer tous les livres
        [HttpGet("books")]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _catalogManager.DisplayCatalog();
            return Ok(books);
        }

        // Endpoint pour récupérer un livre par son ID
        [HttpGet("book/{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _catalogManager.FindBook(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // Endpoint pour récupérer les livres par type
        [HttpGet("books/{type}")]
        public ActionResult<IEnumerable<Book>> GetBooksByType(string type)
        {
            var books = _catalogManager.DisplayCatalog().Where(b => b.Type.ToString().Equals(type, StringComparison.OrdinalIgnoreCase));
            if (!books.Any())
                return NotFound();

            return Ok(books);
        }

        // Endpoint pour récupérer le livre le mieux noté
        [HttpGet("book/topRatedBook")]
        public ActionResult<Book> GetTopRatedBook()
        {
            var topRatedBook = _catalogManager.GetTopRatedBook();
            if (topRatedBook == null)
                return NotFound();

            return Ok(topRatedBook);
        }
    }
}
