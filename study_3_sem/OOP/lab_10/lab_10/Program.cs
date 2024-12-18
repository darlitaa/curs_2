using System;
using System.Linq;

namespace lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 task
            Console.WriteLine("--------------- 1 ----------------\n");
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            var selectedMonthN = month.Where(m => m.Length == 7);

            Console.WriteLine("Месяцы с названием в 7 символов:");
            foreach (var str in selectedMonthN)
            {
                Console.Write(str + "  ");
            }


            var selectedMonthWinSum = month.Where(m => Array.IndexOf(month, m) < 2 ||
                                            Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8 ||
                                            Array.IndexOf(month, m) == 11);
            Console.WriteLine("\n\nЗимние и летние месяцы:");
            foreach (var str in selectedMonthWinSum)
            {
                Console.Write(str + "  ");
            }


            var selectedMonthAlfa = from m in month
                                    orderby m
                                    select m;
            Console.WriteLine("\n\nМесяц по алфавиту:");
            foreach (var str in selectedMonthAlfa)
            {
                Console.Write(str + "  ");
            }


            var selectedMonthU4 = from m in month
                                  where m.Contains('u') && m.Length > 3
                                  select m;
            Console.WriteLine("\n\nМесяцы содержащие букву «u» и длиной имени не менее 4-х:");
            foreach (var str in selectedMonthU4)
            {
                Console.Write(str + "  ");
            }

            Console.WriteLine("\n\n----------------2 and 3---------------\n");
            // 2,3 task
            var carsList = new List<Car>();

            var car1 = new Car("mers", 2008, "red", 1234567, "universal", 1000);
            var car2 = new Car("mustang", 2013, "black", 0765487, "universal", 1001);
            var car3 = new Car("audi", 2020, "pink", 8345621, "universal", 1002);
            var car4 = new Car("audi", 2009, "blue", 8340921, "sidan", 1003);
            var car5 = new Car("bmw", 2011, "black", 0701487, "sidan", 1004);
            var car6 = new Car("mers", 2020, "blue", 1200567, "universal", 1005);
            var car7 = new Car("ford", 2023, "pink", 1299567, "universal", 1006);
            var car8 = new Car("ford", 2020, "blue", 1288567, "universal", 1007);
            var car9 = new Car("mers", 2020, "grey", 1201167, "universal", 1008);
            var car10 = new Car("mustang", 2005, "grey", 1131167, "sport", 1009);

            carsList.AddRange(new List<Car> { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10 });


            Console.Write("\nВведите марку автомобиля:");
            string? console_brand = Console.ReadLine();
            var carsByBrand = carsList.Where(m => m._brand.Equals(console_brand));

            foreach (var car in carsByBrand)
            {
                Console.WriteLine(car);
            }


            Console.Write("\nВведите модель автомобиля:");
            string? console_model = Console.ReadLine();
            Console.Write("Введите количество лет:");
            int n = int.Parse(Console.ReadLine() ?? "0");
            var carsByModel = carsList.Where(m => m._model.Equals(console_model) && (DateTime.Now.Year - m.YearOfRelease > n));

            foreach (var car in carsByModel)
            {
                Console.WriteLine(car);
            }


            Console.Write("\nВведите цвет автомобиля:");
            string? console_color = Console.ReadLine();
            Console.Write("Введите минимальную цену:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Введите максимальную цену:");
            int maxPrice = int.Parse(Console.ReadLine());
            var countByColorAndPrice = carsList.Count(m => m._color.Equals(console_color) && m._price >= minPrice && m._price <= maxPrice);

            Console.WriteLine($"\nКоличество автомобилей цвета {console_color} в диапазоне цен от {minPrice} до {maxPrice}: {countByColorAndPrice}");


            var oldestCar = carsList.OrderBy(m => m.YearOfRelease).FirstOrDefault();
            Console.WriteLine($"\nСамый старый автомобиль: {oldestCar}");


            var newestCars = carsList.OrderByDescending(m => m.YearOfRelease).Take(5);
            Console.WriteLine("\nПервые пять самых новых автомобилей:");
            foreach (var car in newestCars)
            {
                Console.WriteLine(car);
            }


            var sortedByPrice = carsList.OrderBy(m => m._price).ToArray();
            Console.WriteLine("\nУпорядоченный массив автомобилей по цене:");
            foreach (var car in sortedByPrice)
            {
                Console.WriteLine(car);
            }


            Console.WriteLine("\n--------------- 4 ----------------\n");
            //task 4

            var myCar = from c in carsList
                        where c._brand == "mers"
                        group c by c._color into grouped
                        orderby grouped.Max(car => car._price) descending
                        select grouped;

            foreach (var group in myCar)
            {
                Console.WriteLine($"Цвет: {group.Key}, Макс. цена: {group.Max(car => car._price)}");
            }

            Console.WriteLine("\n--------------- 5 ----------------\n");
            // 5 task
            var carsList2 = new List<Car>();

            var carNew = new Car("volga", 2008, "red", 1234567, "sidan", 1000);
            carsList2.Add(carNew);

            var joinedCars = carsList.Join(
                 carsList2,
                 car => car.YearOfRelease,
                 car2 => car2.YearOfRelease,
                 (car1, car2) => new { Car1 = car1, Car2 = car2 });

            foreach (var cars in joinedCars)
            {
                Console.WriteLine(cars);
            }
            
        }
    }
}