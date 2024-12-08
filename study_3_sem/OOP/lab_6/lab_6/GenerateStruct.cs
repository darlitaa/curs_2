using System;

namespace lab_6
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