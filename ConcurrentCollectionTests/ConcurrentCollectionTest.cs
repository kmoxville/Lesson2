using ConcurrentCollection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ConcurrentCollectionTests
{
    public class ConcurrentCollectionTest
    {
        [Fact]
        public void ConcurrentCollaction_Add_ShouldSuccess()
        {
            // setup
            int count = 1000;
            List<int> list = new List<int>();
            ICollection<int> collection = new ConcurrentCollection<int>(list);

            // action
            Parallel.ForEach(Enumerable.Range(0, count), (x, token) => collection.Add(x));
            Parallel.ForEach(Enumerable.Range(0, count / 2), (x, token) => collection.Remove(x));

            // asserts
            Assert.Equal(count / 2, collection.Count);
            Assert.True(collection.Contains(501));
            Assert.False(collection.Contains(0));
        }
    }
}