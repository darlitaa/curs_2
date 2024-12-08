using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public abstract class Product
    {
        public string? Manufacturer { get; set; }
        public double Cost { get; set; }

        public Product(string? manufacturer, double cost)
        {
            Manufacturer = manufacturer;
            Cost = cost;
        }

        public abstract void GetCost();

        public override string ToString()
        {
            return $"\tИнформация о продукте\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n";
        }

    }
}