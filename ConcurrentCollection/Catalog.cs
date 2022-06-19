using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollection
{
    public class Catalog : IEnumerable<Product>
    {
        private ConcurrentDictionary<CatalogKey, Product> _products;

        public Catalog()
        {
            _products = new();
        }

        public Catalog Add(Product product)
        {
            if (!_products.TryAdd(product.Id, product))
                throw new ArgumentException();

            return this;
        }

        public Catalog Delete(CatalogKey id)
        {
            if (!_products.TryRemove(id, out _))
                throw new ArgumentException();

            return this;
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return _products.Values.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
