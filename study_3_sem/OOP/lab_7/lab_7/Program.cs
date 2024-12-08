using Newtonsoft.Json;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass<int> num1 = new MyClass<int>(1);
            MyClass<double> num2 = new MyClass<double>(1.1);
            MyClass<string> num3 = new MyClass<string>("one");

            num1.PrintType();
            num2.PrintType();
            num3.PrintType();
            Console.WriteLine("\n");

            try
            {
                var Medovik = new Cake("BelCake", 22.22, "01.10.2024", 10.5, 1.7, 20);
                MyList<Cake> list = new MyList<Cake>(Medovik);

                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText("output.json", json);

                string jsonFromFile = File.ReadAllText("output.json");
                Console.WriteLine(jsonFromFile);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка выполнения программы: {e.Message}");
                Console.WriteLine($"Место ошибки: {e.StackTrace}");
            }
            finally
            {
                Console.WriteLine("блок finally");
            }
        }
    }
}