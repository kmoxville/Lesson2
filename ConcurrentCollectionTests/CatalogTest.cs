using ConcurrentCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ConcurrentCollectionTests
{
    public class CatalogTest
    {
        [Fact]
        public void ConcurrentCollaction_Add_ShouldFail()
        {
            // setup
            Catalog catalog = new Catalog();

            catalog.Add(new Product { Id = 1, Name = "test1" })
                .Add(new Product { Id = 2, Name = "test2" })
                .Add(new Product { Id = 3, Name = "test3" })
                .Add(new Product { Id = 4, Name = "test4" })
                .Add(new Product { Id = 5, Name = "test5" });

            // asserts
            Assert.Throws<ArgumentException>(() => catalog.Add(new Product { Id = 1, Name = "test1" }));
        }

        [Fact]
        public void ConcurrentCollaction_Delete_ShouldFail()
        {
            // setup
            Catalog catalog = new Catalog();

            catalog.Add(new Product { Id = 1, Name = "test1" })
                .Add(new Product { Id = 2, Name = "test2" })
                .Add(new Product { Id = 3, Name = "test3" })
                .Add(new Product { Id = 4, Name = "test4" })
                .Add(new Product { Id = 5, Name = "test5" });

            // asserts
            Assert.Throws<ArgumentException>(() => catalog.Delete(id: 6));
        }
    }
}
