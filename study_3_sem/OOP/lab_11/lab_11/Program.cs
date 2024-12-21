using System;

namespace lab_11
{
    public class Program
    {
        static void Main()
        {
            Type myType = typeof(lab_11.Rectangle);
            //Type myType = typeof(lab_11.Stack);
            Console.WriteLine($"Информация о классе записана в файл");
            Reflector.GetTypeInfo(myType, "System.Int32");
        }
    }
}