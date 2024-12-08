using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8
{
    public class ProgrammerList
    {
        private List<Programmer> programmers = new List<Programmer>();

        public void Add(Programmer programmer) => programmers.Add(programmer);

        public void RemoveFirst()
        {
            if (programmers.Count > 0)
            {
                Console.WriteLine($"Удаляем первого: {programmers[0].Name}");
                programmers.RemoveAt(0);
            }
        }

        public void RemoveLast()
        {
            if (programmers.Count > 0)
            {
                Console.WriteLine($"Удаляем последнего: {programmers[^1].Name}");
                programmers.RemoveAt(programmers.Count - 1);
            }
        }

        public void RandomMutate()
        {
            if (programmers.Count > 1)
            {
                Random random = new Random();
                int index1 = random.Next(programmers.Count);
                int index2;

                do
                {
                    index2 = random.Next(programmers.Count);
                } while (index1 == index2);

                var temp = programmers[index1];
                programmers[index1] = programmers[index2];
                programmers[index2] = temp;

                Console.WriteLine($"Случайное перемещение: {programmers[index1].Name} и {programmers[index2].Name}");
            }
        }

        public override string ToString()
        {
            if (programmers.Count == 0)
                return "Список программистов пуст.";

            return string.Join(", ", programmers.ConvertAll(p => p.Name));
        }
    }
}