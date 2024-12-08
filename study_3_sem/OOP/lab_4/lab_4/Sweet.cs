using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4
{
    public abstract class Sweet : Product
    {
        public string? Expiration { get; set; }
        public Sweet(string? manufacturer, double cost, string? expiration) : base(manufacturer, cost)
        {
            Expiration = expiration;
        }
        
        public virtual void GetStorageConditions()
        {
            Console.WriteLine("У этой сладости нет собственных условий хранения");
        }

        public abstract void GetExpiration();

        public override void GetCost()
        {
            Console.WriteLine($"Эта сладость стоит: {Cost}");
        }

        public override string ToString()
        {
            return $"\tИнформация о сладостях\n " +
                   $"\tПроизводитель: {Manufacturer} \n" +
                   $"\tСтоимость: {Cost} \n" +
                   $"\tСрок годности: {Expiration} \n";
        }

    }
}
