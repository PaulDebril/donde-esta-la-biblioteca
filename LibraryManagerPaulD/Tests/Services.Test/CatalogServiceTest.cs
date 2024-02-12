using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Services.Test
{
    [TestClass]
    public class CatalogServiceTest
    {
        [TestMethod]
        public void ShowCatalog_Returns_Catalog_From_CatalogManager()
        {
            var catalogManagerMock = new Mock<ICatalogManager>();
            var expectedCatalog = new List<Book>
            {
                new Book() { Id = 1, Name = "Book 1", Type = BookType.Fantasy, Rate = 2 },
                new Book() { Id = 2, Name = "Book 2", Type = BookType.Fiction, Rate = 4 }
            };
            catalogManagerMock.Setup(manager => manager.DisplayCatalog()).Returns(expectedCatalog);
            var catalogService = new CatalogService(catalogManagerMock.Object);

            var result = catalogService.ShowCatalog();

            CollectionAssert.AreEqual(expectedCatalog, result.ToList());
        }

        [TestMethod]
        public void ShowCatalogWithType_Returns_Filtered_Catalog_From_CatalogManager()
        {
            var catalogManagerMock = new Mock<ICatalogManager>();
            var type = "Fantasy";
            var expectedCatalog = new List<Book>
            {
                new Book() { Id = 1, Name = "Book 1", Type = BookType.Fantasy, Rate = 2 },
                new Book() { Id = 3, Name = "Book 3", Type = BookType.Fantasy, Rate = 3 }
            };
            catalogManagerMock.Setup(manager => manager.DisplayCatalog(type)).Returns(expectedCatalog);
            var catalogService = new CatalogService(catalogManagerMock.Object);

            var result = catalogService.ShowCatalog(type);

            CollectionAssert.AreEqual(expectedCatalog, result.ToList());
        }

        [TestMethod]
        public void FindBook_Returns_Book_From_CatalogManager()
        {
            var catalogManagerMock = new Mock<ICatalogManager>();
            var bookId = 1;
            var expectedBook = new Book() { Id = 1, Name = "Book 1", Type = BookType.Fantasy, Rate = 2 };
            catalogManagerMock.Setup(manager => manager.FindBook(bookId)).Returns(expectedBook);
            var catalogService = new CatalogService(catalogManagerMock.Object);

            var result = catalogService.FindBook(bookId);

            Assert.AreEqual(expectedBook, result);
        }

        [TestMethod]
        public void DisplayFantasyBooks_Returns_Filtered_Catalog_From_CatalogManager()
        {
            var catalogManagerMock = new Mock<ICatalogManager>();
            var expectedCatalog = new List<Book>
            {
                new Book() { Id = 1, Name = "Book 1", Type = BookType.Fantasy, Rate = 2 },
                new Book() { Id = 3, Name = "Book 3", Type = BookType.Fantasy, Rate = 3 }
            };
            catalogManagerMock.Setup(manager => manager.DisplayFantasyBooks()).Returns(expectedCatalog);
            var catalogService = new CatalogService(catalogManagerMock.Object);

            var result = catalogService.DisplayFantasyBooks();

            CollectionAssert.AreEqual(expectedCatalog, result.ToList());
        }

        [TestMethod]
        public void GetTopRatedBook_Returns_Top_Rated_Book_From_CatalogManager()
        {
            var catalogManagerMock = new Mock<ICatalogManager>();
            var expectedBook = new Book() { Id = 2, Name = "Book 2", Type = BookType.Fiction, Rate = 4 };
            catalogManagerMock.Setup(manager => manager.GetTopRatedBook()).Returns(expectedBook);
            var catalogService = new CatalogService(catalogManagerMock.Object);

            var result = catalogService.GetTopRatedBook();

            Assert.AreEqual(expectedBook, result);
        }
    }
}
