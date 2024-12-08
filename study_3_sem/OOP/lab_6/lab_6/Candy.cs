using System;

namespace lab_6
{
    public class Candy : Sweet, IExpiration
    {
        public string? Kind { get; set; }

        public Candy(string? manufacturer, double cost, string? expiration, string? kind) : base(manufacturer, cost, expiration)
        {
            Kind = kind;
        }

        public override void GetStorageConditions()
        {
            Console.WriteLine("Вам следует отнести конфеты в такое место, где нет солнца ");
        }


        public override void GetExpiration()
        {
            Console.WriteLine($"Срок годности этих конфет истекает: {Expiration} (реализованно через абстрактный класс)");
        }

        void IExpiration.GetExpiration()
        {
            Console.WriteLine($"Срок годности этих конфет истекает: {Expiration} (реализованно через интерфейс)");
        }


        public override string ToString()
        {
            return $"\tИнформация о конфете\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tСрок годности: {Expiration} \n" +
                   $"\tВид: {Kind} \n";
        }

    }
}