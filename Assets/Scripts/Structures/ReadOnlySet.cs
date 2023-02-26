using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Structures
{
    public static class SetExtensionMethods
    {
        public static ReadOnlySet<T> AsReadOnly<T>(this ISet<T> set)
        {
            return new ReadOnlySet<T>(set);
        }
    }
    public class ReadOnlySet<T> : IReadOnlyCollection<T>
    {
        private readonly ISet<T> _set;
        public ReadOnlySet(ISet<T> set)
        {
            _set = set;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _set.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_set).GetEnumerator();
        }

        public bool Contains(T item)
        {
            return _set.Contains(item);
        }

        public int Count
        {
            get { return _set.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }
    }
}
