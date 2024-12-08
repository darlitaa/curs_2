using System;
using System.Numerics;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace lab_7
{

    public class MyList<T> : IAll<T> where T : class
    {
        public List<T> _list;

        public MyList(T initialValue)
        {
            _list = new List<T> { initialValue };
        }

        void IAll<T>.Add(T item)
        {
            _list.Add(item);
        }

        void IAll<T>.Delete(T item)
        {
            _list.Remove(item);
        }

        void IAll<T>.Get()
        {
            foreach (var item in _list)
            {
                Console.WriteLine("val:" + item);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _list.Count)
                    throw new ArgumentOutOfRangeException();

                return _list[index];
            }
            set
            {
                if (index < 0 || index >= _list.Count)
                    throw new ArgumentOutOfRangeException();

                _list[index] = value;
            }
        }


    }
}