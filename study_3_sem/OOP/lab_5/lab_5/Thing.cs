using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public class Thing : Product
    {
        public string? TargetAudience { get; set; }

        public Thing(string? manufacturer, double cost, string? targetAudience) : base(manufacturer, cost)
        {
            TargetAudience = targetAudience;
        }

        public override void GetCost()
        {
            Console.WriteLine($"Этот товар стоит: {Cost}");
        }

        public override string ToString()
        {
            return $"\tИнформация о товаре\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tЦелевая аудитория: {TargetAudience} \n";
        }

    }
}
