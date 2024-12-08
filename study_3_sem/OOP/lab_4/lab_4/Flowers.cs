using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public class Flowers : Thing
    {
        public int Size { get; set; }

        public Flowers(string? manufacturer, double cost, string? targetAudience, int size) : base(manufacturer, cost, targetAudience)
        {
            Size = size;
        }
        public override string ToString()
        {
            return $"\tИнформация о цветах\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tЦелевая аудитория: {TargetAudience} \n" +
                   $"\tРазмер: {Size} \n";
        }

    }
}
