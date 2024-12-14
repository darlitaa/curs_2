using System;
using System.Collections;

namespace lab_9
{
    public class Image<T> : ISet<T>
    {
        private T[] _image = new T[10];
        private int _count;
        public Image()
        {
            _count = 0;
        }

        public int Count { get { return _count; } }

        public bool IsReadOnly { get { return false; } }

        public bool Add(T item)
        {
            if (_count < _image.Length)
            {
                _image[_count] = item;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            bool inObj = false;
            for (int i = 0; i < _count; i++)
            {
                if (_image[i].Equals(item))
                {
                    inObj = true;
                    break;
                }
            }
            return inObj;
        }

        #region
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion 
    }
}
