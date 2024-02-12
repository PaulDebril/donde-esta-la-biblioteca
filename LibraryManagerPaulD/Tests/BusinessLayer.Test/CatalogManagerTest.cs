using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Services;
using BusinessLayer.Catalog;
using BusinessObjects.Entity;
using System.Collections.Generic;

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
    }
}
