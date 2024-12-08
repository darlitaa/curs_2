using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public partial class Watch : Thing
    {
        public string? TypeOfMechanism { get; set; }

        public Watch(string? manufacturer, double cost, string? targetAudience, string? typeOfMechanism) : base(manufacturer, cost, targetAudience)
        {
            TypeOfMechanism = typeOfMechanism;
        }

        public override string ToString()
        {
            return $"\tИнформация о часах\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tЦелевая аудитория: {TargetAudience} \n" +
                   $"\tТип механизма: {TypeOfMechanism} \n";
        }

    }
}