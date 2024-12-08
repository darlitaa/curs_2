using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public class PresentController
    {
        public void GetPresentCost(Present present)
        {
            Present sortByMassPresent = (Present)present.List.OrderByDescending(n => n);
            foreach (var item in present.List)
            {
                double presentCost = 0;
                presentCost += item.Cost;
                Console.WriteLine(presentCost);
            }
        }

        public void GetLowMassPresent(Present present)
        {
            Present sortByMassPresent = (Present)present.List.OrderBy(n => n);
            Console.WriteLine(sortByMassPresent.List[0]);
        }

        public void SortByMassPresent(Present present)
        {
            Present sortByMassPresent = (Present)present.List.OrderBy(n => n);
            Console.WriteLine(sortByMassPresent.List);
        }

    }
}
