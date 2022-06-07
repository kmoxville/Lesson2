using System.Collections;
using System.Collections.Immutable;

namespace ConcurrentCollection
{
    public class ConcurrentCollection<T> : ICollection<T>
    {
        private readonly ICollection<T> _collection;
        private readonly object _lock = new object();

        public ConcurrentCollection(ICollection<T> collection)
        {
            _collection = collection;
        }

        public int Count
        {
            get 
            { 
                return _collection.Count; 
            }
        }

        public bool IsReadOnly => _collection.IsReadOnly;

        public void Add(T item)
        {
            lock (_lock)
            _collection.Add(item);
        }

        public void Clear()
        {
            lock(_lock)
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock(_lock)
            _collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ImmutableList.CreateRange(this).GetEnumerator();
        }

        public bool Remove(T item)
        {
            lock(_lock)
            return _collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}