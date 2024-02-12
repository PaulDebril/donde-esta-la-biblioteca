using System;
using System.Collections.Generic;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository : IGenericRepository<Author>
    {
        private List<Author> ListAuthors = new List<Author>();

        public IEnumerable<Author> GetAll()
        {
            return ListAuthors;
        }

        public Author Get(int AuthorId)
        {
            return new Author();;
        }
    }
}