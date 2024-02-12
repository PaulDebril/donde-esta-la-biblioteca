using System;
using System.Collections.Generic;
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository : IGenericRepository<Library>
    {
        private List<Library> ListLibrary = new List<Library>();

        public IEnumerable<Library> GetAll()
        {
            return ListLibrary;
        }

        public Library Get(int LibraryId)
        {
            return new Library();;
        }
    }
}

