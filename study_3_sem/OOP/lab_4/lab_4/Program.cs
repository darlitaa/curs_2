using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var Medovik = new Cake("BelCake", 22.22, "01.10.2024", 10.5, 1.7, 20);
            var Alenka = new Candy("BelCandy", 1.2, "02.12.2025", "с топпингом");
            var Roses = new Flowers("Kvetka", 40.2, "девушка", 21);
            var Rolex = new Watch("Rolex", 999.9 , "мужчина", "хронографический");

            Medovik.GetExpiration();
            ((IExpiration)Medovik).GetExpiration();
            Console.WriteLine();


            if (Medovik is IExpiration)
            {
                Console.WriteLine("true (Medovik is IExpiration)");
            }
            else
            {
                Console.WriteLine("false (Medovik is IExpiration)");
            }
            Console.WriteLine();


            IExpiration medovik = Medovik;
            if (medovik as Cake != null)
            {
                Console.WriteLine($"({medovik}) medovik as Cake\n");
            }
            Console.WriteLine("-----------------------------\n");


            Printer Printer = new Printer();
            Product[] array = new Product[] {Alenka, Roses, Rolex };

            foreach (var element in array)
            {
                Printer.IAmPrinting(element);
            }

        }
    }
}
