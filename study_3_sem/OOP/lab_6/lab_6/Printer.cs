using System;

namespace lab_6
{
    public class Printer
    {
        public void IAmPrinting(Product element)
        {
            Console.WriteLine($"Type object({element.GetType()}):");
            Console.WriteLine(element.ToString());
        }
    }
}