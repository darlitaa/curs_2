using System.Collections.Concurrent;
using System.Diagnostics;

namespace Lab_15;

class Program
{
    public static void Main()
    {
        Task1();
        Task2();
        Task3();
        Task4();
        Task5();
        Task6();
        Task7();
        Task8();
    }

    public static void EratosthenesSieve_1(int n)       // решето Эратосфена
    {
        System.Threading.Thread.Sleep(100); 
        var flags = new bool[n];

        for (var i = 0; i < flags.Length; i++)
            flags[i] = true;

        flags[1] = false;
        for (int i = 2, j; i < n;)
        {
            if (flags[i])
            {
                j = i * 2;
                while (j < n)
                {
                    flags[j] = false;
                    j += i;
                }
            }
            i++;
        }

        Console.WriteLine($"Все простые числа до {n}:");
        for (var i = 2; i < flags.Length; i++)
        {
            if (flags[i])
            {
                Console.Write($" {i} ");
            }
        }
        Console.WriteLine();
    }

    public static CancellationTokenSource TokenSource = new();
    public static void EratosthenesSieve_2(int n)
    {
        System.Threading.Thread.Sleep(100);

        var flags = new bool[n];

        for (var i = 0; i < flags.Length; i++)
            flags[i] = true;

        flags[1] = false;
        for (int i = 2, j; i < n;)
        {
            Console.WriteLine($"Задача выполняется #{Task.CurrentId}.");
            System.Threading.Thread.Sleep(900);
            if (flags[i])
            {
                j = i * 2;
                while (j < n)
                {
                    flags[j] = false;
                    j += i;
                }
            }
            i++;

            if (TokenSource.IsCancellationRequested)
            {
                Console.WriteLine("\nПреждевременная остановка!");
                return;
            }
        }

        Console.WriteLine($"Все простые числа до {n}:  ");
        for (var i = 2; i < flags.Length; i++)
        {
            if (flags[i])
            {
                Console.Write($" {i} ");
            }
        }
        Console.WriteLine();
    }



    public static void Task1()
    {
        Console.Write("Введите n: ");
        var n = Convert.ToInt32(Console.ReadLine());

        var sw = new Stopwatch();
        var task = new Task(() => EratosthenesSieve_1(n));
        Console.WriteLine($"Задача #{task.Id} статус - {task.Status}");
        task.Start();

        sw.Start();

        while (true)
        {
            System.Threading.Thread.Sleep(100);
            Console.WriteLine($"\nСтатус задачи #{task.Id} - {task.Status}");
            if (task.Status == TaskStatus.RanToCompletion)
                break;
        }

        sw.Stop();
        Console.WriteLine($"Статус задачи #{task.Id} - {task.Status}");
        Console.WriteLine($"Общее время выполнения: {sw.ElapsedMilliseconds} мс");
    }

    public static void Task2()
    {
        Console.Write("Введите n: ");
        var n = Convert.ToInt32(Console.ReadLine());

        var task2 = new Task(() => EratosthenesSieve_2(n));
        Console.WriteLine($"Задача #{task2.Id} статус - {task2.Status}");
        task2.Start();

        Console.WriteLine("\nЧтобы остановить задачу, нажмите 0:");
        var s = Console.ReadLine();
        if (s == "0")
            TokenSource.Cancel();

        Console.WriteLine($"Задача #{task2.Id} статус - Завершена");
    }

    public static void Task3()
    {
        var rand = new Random();
        var rand1 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 1 + 2; });
        var rand2 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 3 + 4; });
        var rand3 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 5 + 6; });
        rand1.Start(); rand2.Start(); rand3.Start();


        int Sum(int a, int b, int c) { return a + b + c; }

        var result = new Task<int>(() => Sum(rand1.Result, rand2.Result, rand3.Result));
        result.Start();

        Console.WriteLine("Результат задачи 3: " + result.Result);
    }

    public static void Task4()
    {
        int Sum(int a, int b) => a + b;
        void Display(int sum) { Console.WriteLine($"Сумма: {sum}"); }

        var task1 = new Task<int>(() => Sum(4, 5));
        var task2 = new Task<int>(() => Sum(10, 15));

        task1.Start();
        task2.Start();

        var task3 = task1.ContinueWith(sum => Display(sum.Result));    //задача с продолжением

        var continuationTask = Task.Run(() =>
        {
            var result1 = task1.GetAwaiter().GetResult();
            var result2 = task2.GetAwaiter().GetResult();
            var sum = result1 + result2;
            Display(sum);
        });

        Console.Read();
    }

    public static void Task5()
    {
        int Factorial(int x)
        {
            var result = 1;
            for (var i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        var arr1 = new int[10][];
        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var stopwatch = Stopwatch.StartNew();


        Parallel.For(0, arr1.Length, i =>
        {
            arr1[i] = new int[10000000];
        });
        stopwatch.Stop();
        Console.WriteLine($"Время на создание массивов: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();
        Parallel.ForEach(list, (a) =>
        {
            Console.WriteLine($"Факториал числа {a} = {Factorial(a)}");
        });
        stopwatch.Stop();
        Console.WriteLine($"Время на расчет факториалов: {stopwatch.ElapsedMilliseconds} мс");



        stopwatch.Restart();
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = new int[10000000];
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на последовательное создание массивов: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();
        foreach (var a in list)
        {
            Console.WriteLine($"Факториал числа {a} = {Factorial(a)}");
        }
        stopwatch.Stop();
        Console.WriteLine($"Время на последовательный расчет факториалов: {stopwatch.ElapsedMilliseconds} мс\n\n");
        
    }

    public static void Task6()
    {
        var st = Stopwatch.StartNew();
        st.Start();
        Parallel.Invoke
        (
            () => { Thread.Sleep(1000); Console.WriteLine($"Задача в процессе {Task.CurrentId}"); Thread.Sleep(5000); },
            () => { Thread.Sleep(1000); Console.WriteLine($"Задача в процессе {Task.CurrentId}"); Thread.Sleep(5000); },
            () => { Thread.Sleep(1000); Console.WriteLine($"Задача в процессе {Task.CurrentId}"); Thread.Sleep(5000); },
            () => { Thread.Sleep(1000); Console.WriteLine($"Задача в процессе {Task.CurrentId}"); Thread.Sleep(5000); },
            () => { Thread.Sleep(1000); Console.WriteLine($"Задача в процессе {Task.CurrentId}"); Thread.Sleep(5000); }
        );
        st.Stop();
        Console.WriteLine("Все задачи завершены");
        Console.WriteLine($"Время выполнения 5-ти параллельных задач: {st.ElapsedMilliseconds} мс\n\n");
    }


    private static BlockingCollection<string> bc = new BlockingCollection<string>(5);
    private static readonly object lockObj = new object(); 

    public static void Task7()
    {
        // Продавцы 
        var sellers = new Task[]
        {
            new(() => { while (true) { Thread.Sleep(700); AddItem("Холодильник"); } }),
            new(() => { while (true) { Thread.Sleep(900); AddItem("Микроволновка"); } }),
            new(() => { while (true) { Thread.Sleep(800); AddItem("Телевизор"); } }),
            new(() => { while (true) { Thread.Sleep(600); AddItem("Пылесос"); } }),
            new(() => { while (true) { Thread.Sleep(750); AddItem("Стиральная машина"); } })
        };

        // Покупатели
        var consumers = new Task[]
        {
            new(() => { while (true) { Thread.Sleep(200); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(300); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(400); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(350); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(500); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(450); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(550); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(600); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(650); TryBuy(); } }),
            new(() => { while (true) { Thread.Sleep(700); TryBuy(); } })
        };

       
        foreach (var seller in sellers)
            seller.Start();

        
        foreach (var consumer in consumers)
            consumer.Start();

        // Состояние склада
        while (true)
        {
            Thread.Sleep(600); 
            PrintWarehouse();
        }
    }

    private static void AddItem(string item)
    {
        bc.Add(item);
        lock (lockObj)
        {
            Console.WriteLine($"Поставщик добавил: {item}");
            PrintWarehouse();
        }
    }

    private static void PrintWarehouse()
    {
        lock (lockObj)
        {
            Console.WriteLine("----------Склад----------");
            foreach (var i in bc.ToArray())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
        }
    }

    private static void TryBuy()
    {
        if (bc.TryTake(out string item))
        {
            Console.WriteLine($"Покупатель купил: {item}");
        }
        else
        {
            Console.WriteLine("Покупатель не нашёл товара и ушёл.");
        }
    }


    public static void Task8()
    {
        void Factorial()
        {
            var result = 1;
            for (var i = 1; i <= 6; i++)
            {
                result *= i;
            }
            Thread.Sleep(5000);
            Console.WriteLine($"Факториал равен {result}");
        }

        async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync");
            await Task.Run(Factorial);
            Console.WriteLine("Конец метода FactorialAsync");
        }

        FactorialAsync();
        Console.WriteLine("Основной поток продолжает выполнение");
    }
}