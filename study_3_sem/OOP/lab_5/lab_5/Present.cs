using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public class Present
    {

        private List<Product> _list;

        public Present()
        {
            _list = new List<Product>();
        }

        public List<Product> List
        {
            get => _list;
            set
            {
                if (value is List<Product>)
                {
                    _list = value;
                }
            }
        }

        public void Add(object value)
        {
            if (value is Product present)
            {
                _list.Add(present);
            }
        }

        public void Remove(object value)
        {
            if (value is Product present)
            {
                _list.Remove(present);
            }
        }

        public void Print()
        {
            foreach (var present in _list)
            {
                Console.WriteLine(present);
            }
        }

    }
}
