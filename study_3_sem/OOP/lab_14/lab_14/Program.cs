using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

namespace lab_14;

class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
    }


    private static void Task1()
    {
        var allProcesses = Process.GetProcesses();
        Console.WriteLine("Информация о процессах:");
        Console.Write("{0,-15}", "ID:");
        Console.Write("{0,-40}", "Имя:");
        Console.Write("{0,-20}", "Приоритет:");
        Console.Write("{0,-30}", "Время запуска:");
        Console.Write("{0,-20}", "Состояние:");
        Console.Write("{0,-30}", "Время ЦП (мс):\n");

        foreach (var process in allProcesses)
        {
            try
            {
                Console.WriteLine();
                Console.Write("{0,-15}", process.Id);
                Console.Write("{0,-40}", process.ProcessName);
                Console.Write("{0,-20}", process.BasePriority);
                Console.Write("{0,-30}", process.StartTime);
                Console.Write("{0,-20}", process.Responding ? "Работает" : "Не отвечает");
                Console.Write("{0,-30}", process.TotalProcessorTime.TotalMilliseconds);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не доступно {process.Id}: {ex.Message}");
            }
        }
    }


    private static void Task2()
    {
        var domain = AppDomain.CurrentDomain;
        Console.WriteLine("Информация о текущем домене:");
        Console.WriteLine("\n\nТекущий домен:\t" + domain.FriendlyName);
        Console.WriteLine("Базовый каталог:\t" + domain.BaseDirectory);
        Console.WriteLine("Детали конфигурации:\t" + domain.SetupInformation);
        Console.WriteLine("Все сборки в домене:\n");

        foreach (var assembly in domain.GetAssemblies())
        {
            Console.WriteLine(assembly.GetName().Name);
        }

        //CreateAndLoadNewDomain();
    }
    //private static void CreateAndLoadNewDomain()
    //{
    //    AppDomain NewDomain = AppDomain.CreateDomain("TestDomain");
    //    Console.WriteLine($"\n\nСоздан новый домен: {NewDomain}");
    //    Console.WriteLine($"Загрузка сборки в новый домен {NewDomain.FriendlyName}");
    //    NewDomain.Load(Assembly.GetExecutingAssembly().FullName);
    //    Console.WriteLine($"Выгрузка сборки {NewDomain.BaseDirectory}");
    //    AppDomain.Unload(NewDomain);
    //}


    private static void Task3()
    {
        Thread primeThread = null;

        Console.Write("\n\nВведите число n: ");
        int n = int.Parse(Console.ReadLine());

        primeThread = new Thread(() =>
        {
            using (StreamWriter writer = new StreamWriter("primes.txt"))
            {
                for (int i = 2; i <= n; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                        Thread.Sleep(600);
                    }
                }
            }
        })
        {
            Name = "PrimeNumberThread"
        };          

        primeThread.Start();

        while (primeThread.IsAlive)
        {
            Console.WriteLine($"\nИмя потока: {primeThread.Name}, ID: {primeThread.ManagedThreadId}, Статус: {(primeThread.IsAlive ? "Работает" : "Завершен")}");
            Thread.Sleep(1200);
        }

        primeThread.Join();
        Console.WriteLine("Поток завершен.");
    }

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
            if (number % i == 0) return false;
        return true;
    }



    public static readonly object lockObject = new object();
    public static bool evenTurn = true;

    public static void Task4()
    {
        //Synchronization.ChangedPriority();

        //Synchronization.PrintEvenOdd();

        Synchronization.PrintOneByOne();

    }



    private static void Task5()
    {
        //TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);

        //Timer timer = new Timer(timerCallback, null, 500, 2000);

        //Thread.Sleep(10000);
        //timer.Change(Timeout.Infinite, 2000);

        //void WhatTimeIsIt(object obj)
        //{
        //    Console.WriteLine($"Сейчас {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
        //}
    }

}
