using lab_7;
using System;
using System.Xml;

namespace lab_7
{
    public class MyClass<T>
    {
        public T Value { get; set; }
        public MyClass(T valye)
        {
            Value = valye;
        }
        public void PrintType()
        {
            Console.WriteLine(typeof(T));
        }
    }
}