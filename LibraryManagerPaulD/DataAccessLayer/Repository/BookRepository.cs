using System;
using System.Collections.Generic;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class BookRepository : IGenericRepository<Book>
    {
        private List<Book> ListBooks = new List<Book>();

        public IEnumerable<Book> GetAll()
        {
            var list = new List<Book>
            {
                new Book() { Id = 1, Name = "Book 1", Type = BookType.Fantasy, Rate = 2 },
                new Book() { Id = 2, Name = "Book 2", Type = BookType.Fiction, Rate = 4 }
            };
            return list;
        }

        public Book Get(int bookId)
        {
            return new Book(); ;
        }
    }
}

