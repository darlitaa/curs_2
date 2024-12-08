using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5
{
    public struct GenerateStruct
    {
        public string Name;
        public int Age;

        public GenerateStruct(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Print()
        {
            Console.WriteLine($"Name: {Name}  Age: {Age}");
        }
    }
}
