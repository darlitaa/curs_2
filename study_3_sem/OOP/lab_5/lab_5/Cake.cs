using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public sealed class Cake : Sweet, IExpiration
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }

        public Cake(string? manufacturer, double cost, string? expiration, double height, double weight, double width) : base(manufacturer, cost, expiration)
        {
            Height = height;
            Weight = weight;
            Width = width;
        }

        public override void GetStorageConditions()
        {
            Console.WriteLine("Тебе следует отнести торт в холодильник");
        }


        public override void GetExpiration()
        {
            Console.WriteLine($"Срок годности торта истекает: {Expiration} (реализованно через абстрактный класс)");
        }

        void IExpiration.GetExpiration()
        {
            Console.WriteLine($"Срок годности торта истекает: {Expiration} (реализованно через интерфейс)");
        }


        public override string ToString()
        {
            return $"\tИнформация о торте\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tСрок годности: {Expiration} \n" +
                   $"\tВысота: {Height} \n" +
                   $"\tВес: {Weight} \n" +
                   $"\tШирина: {Width} \n";
        }

    }
}
