using System;
using System.Linq;

namespace lab_2
{
    internal class Program
    {
        partial class Car
        {   
            public const int YearIsNow = 2024;
            public static int numberOfCars;
            public readonly int Id;

            string mark;
            string model;
            int yearOfRelease;
            string color;
            int price;
            string registrationNumber;

            public string Mark
            {
                get
                {
                    return mark;
                }
                set
                {
                    string[] marks = { "Toyota", "Honda", "Ford" };
                    if (marks.Contains(value)) mark = value;
                    else Console.WriteLine("такой марки машины нет");
                }
            }
            public string Model
            {
                get
                {
                    return model;
                }
                set
                {
                    string[] models = { "Camry", "Civic", "Corolla", "Focus" };
                    if (models.Contains(value)) model = value;
                    else Console.WriteLine("такой модели машины нет");
                }
            }
            public int YearOfRelease
            {
                get
                {
                    return yearOfRelease;
                }
                set
                {
                    if (yearOfRelease > 2025 && yearOfRelease < 0) Console.WriteLine("год выпуска не может быть больше 2024");
                    else yearOfRelease = value;
                }
            }
            public string Color
            {
                get
                {
                    return color;
                }
                set
                {
                    string[] сolors = { "Синий", "Красный", "Зеленый", "Черный", "Белый" };
                    if (сolors.Contains(value)) color = value;
                    else Console.WriteLine("такого цвета машины нет");
                }
            }
            public int Price
            {
                get
                {
                    return price;
                }
                set
                {
                    if (price < 0) Console.WriteLine("Цена не может быть отрицательной");
                    else price = value;
                }
            }
            public string RegistrationNumber
            {
                get
                {
                    return registrationNumber;
                }
                set
                {
                    registrationNumber = value;
                }
            }

            

            static Car()
            {
                numberOfCars = 0;
            }

            
            public Car(string mark, string model, int yearOfRelease, string color, int price, string registrationNumber)
            {
                this.mark = mark;
                this.model = model;
                this.yearOfRelease = yearOfRelease;
                this.color = color;
                this.price = price;
                this.registrationNumber = registrationNumber;
                numberOfCars++;
                Id = GetHashCode();
            }
            
            public Car()
            {
                mark = "Ford";
                model = "Focus";
                yearOfRelease = 2016;
                color = "Черный";
                price = 16800;
                registrationNumber = "D012GH";
                numberOfCars++;
                Id = price * yearOfRelease;
            }
            
            public Car(string mark, int yearOfRelease, string model, string color = "Белый", int price = 12000, string registrationNumber = "E345IJ")
            {
                this.mark = mark;
                this.model = model;
                this.yearOfRelease = yearOfRelease;
                this.color = color;
                this.price = price;
                this.registrationNumber = registrationNumber;
                numberOfCars++;
                Id = GetHashCode();
            }
            

            public static void GetCarAge(ref int YearIsNow, int YearOfRelease, out int carAge)
            {
                carAge = YearIsNow - YearOfRelease;
            }
            public static void ShowStatic()
            {
                Console.WriteLine($"Общее количество автомобилей: {numberOfCars}");
            }
        }

        class Test
        {
            public int test;
            private Test()
            {
                test = 13;
            }
        }

        static void Main(string[] args)
        {
            Car[] cars = new Car[]
            {
                new Car("Toyota", "Camry", 2018, "Синий", 20000, "A123BC"),
                new Car("Honda", "Civic", 2017, "Красный", 18000, "B456CD"),
                new Car("Toyota", "Corolla", 2015, "Зеленый", 15000, "C789EF"),
                new Car(),
                new Car("Honda", 2012,"Civic"),
            };

            foreach (var car in cars)
            {
                Console.WriteLine($"id: {car.Id} {car.Mark} {car.Model} {car.YearOfRelease} {car.Color} {car.Price} {car.RegistrationNumber}");
            }

            Console.WriteLine($"\nВывод стоки:{cars[1].YearOfRelease.ToString()}");
            Console.WriteLine($"Сравнение:{cars[1].YearOfRelease.Equals(cars[2].YearOfRelease)}");
            Console.WriteLine($"Проверка типа:{cars[1].YearOfRelease.GetType()}");

            

            int currentYear = Car.YearIsNow;
            Console.Write("\nВведите ID машины, чтобы узнать её возраст: ");

            if (int.TryParse(Console.ReadLine(), out int GetID))
            {
                var car = Array.Find(cars, c => c.Id == GetID);
                if (car != null)
                {
                    Car.GetCarAge(ref currentYear, car.YearOfRelease, out int age);
                    Console.WriteLine($"Возраст машины: {age} лет ({car.Mark} {car.Model} {car.YearOfRelease} {car.Color} {car.Price} {car.RegistrationNumber})");
                }
                else Console.WriteLine("Машина с таким ID не найдена");
            }
            else Console.WriteLine("Некорректный ввод");

            

            Console.Write("\nВведите марку машины (Toyota, Honda, Ford): ");
            var neededMark = Console.ReadLine();

            foreach (var car in cars)
            {
                if (neededMark == car.Mark)
                {
                    Console.WriteLine($"id: {car.Id} {car.Mark} {car.Model} {car.YearOfRelease} {car.Color} {car.Price} {car.RegistrationNumber}");
                }
            }

            

            Console.WriteLine("\nВведите модель машины (Camry, Civic, Corolla, Focus) и возраст эксплуатации (выведится от введенного и до max): ");
            var neededModel = Console.ReadLine();
            int.TryParse(Console.ReadLine(), out int ageOfOperation);

            foreach (var car in cars)
            {
                Car.GetCarAge(ref currentYear, car.YearOfRelease, out int age);
                if (neededModel == car.Model && age >= ageOfOperation)
                {
                    Console.WriteLine($"id: {car.Id} {car.Mark} {car.Model} {car.YearOfRelease} {car.Color} {car.Price} {car.RegistrationNumber}");
                }
            }

        }
    }
}