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

        // Endpoint pour ajouter un nouveau livre
        [HttpPost("book/add")]
        public ActionResult<Book> AddBook(Book book)
        {
            if (book == null)
                return BadRequest("Le livre à ajouter est null.");

            _catalogManager.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // Endpoint pour mettre à jour un livre existant
        [HttpPut("book/update/{id}")]
        public ActionResult<Book> UpdateBook(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest("L'ID du livre dans l'URL ne correspond pas à l'ID du livre dans le corps de la requête.");

            var existingBook = _catalogManager.FindBook(id);
            if (existingBook == null)
                return NotFound();

            _catalogManager.UpdateBook(book);
            return NoContent();
        }

        // Endpoint pour supprimer un livre
        [HttpDelete("book/delete/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _catalogManager.FindBook(id);
            if (existingBook == null)
                return NotFound();

            _catalogManager.DeleteBook(id);
            return NoContent();
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
