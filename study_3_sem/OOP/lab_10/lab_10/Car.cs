using System;

namespace lab_10
{
    public class Car
    {
        public string _brand { get; set; }
        public string _color { get; set; }
        public uint _registrationNumber { get; set; }
        public string _model { get; set; }
        public int _price;

        private int _yearOfRelease = 0;
        public int YearOfRelease
        {
            get => _yearOfRelease;
            internal set => _yearOfRelease = value;
        }

        public void WriteInf()
        {
            Console.WriteLine($"Марка: {_brand}");
            Console.WriteLine($"Год выпуска: {_yearOfRelease}");
            Console.WriteLine($"Цвет: {_color}");
            Console.WriteLine($"Регистрационный номер: {_registrationNumber}");
            Console.WriteLine($"Модель: {_model}");
            Console.WriteLine($"Цена: {_price}");
            Console.WriteLine("-------------------------------\n");
        }

        public override string ToString()
        {
            return $"{_brand} {_yearOfRelease} {_color} {_registrationNumber} {_model} {_price}";
        }

        public Car(string brand, int yearOfRelease, string color, uint registrationNumber, string model, int price)
        {
            _brand = brand;
            _yearOfRelease = yearOfRelease;
            _color = color;
            _registrationNumber = registrationNumber;
            _model = model;
            _price = price;
            WriteInf();
        }

    }
}