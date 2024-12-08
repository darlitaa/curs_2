using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public class Printer
    {
        public void IAmPrinting(Product element)
        {
            Console.WriteLine($"Тип объекта ({element.GetType()}):");
            Console.WriteLine(element.ToString());
        }
    }
}