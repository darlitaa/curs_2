using System;
using System.Text;
using System.Transactions;

namespace lab_1
{
    class FirstLab
    {
        static void Main()
        {
            int intValue = 2147483647;
            long longValue = 9223372036854775807;
            short shortValue = 32767;
            byte byteValue = 255;

            float floatValue = 3.14f;
            double doubleValue = 3.1458979;

            decimal decimalValue = 348564392.89m;
            bool boolValue = true;
            char charValue = 'L';
            string stringValue = "Hello World";

            Console.WriteLine("Значения переменных:");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"long: {longValue}");
            Console.WriteLine($"short: {shortValue}");
            Console.WriteLine($"byte: {byteValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"double: {doubleValue}");
            Console.WriteLine($"decimal: {decimalValue}");
            Console.WriteLine($"bool: {boolValue}");
            Console.WriteLine($"char: {charValue}");
            Console.WriteLine($"string: {stringValue}");


            Console.WriteLine("\nВведите значения переменных:");

            Console.Write("Введите int: ");
            intValue = int.Parse(Console.ReadLine());

            Console.Write("Введите float: ");
            floatValue = float.Parse(Console.ReadLine());

            Console.Write("Введите bool (true/false): ");
            boolValue = bool.Parse(Console.ReadLine());

            Console.Write("Введите char: ");
            charValue = char.Parse(Console.ReadLine());

            Console.Write("Введите string: ");
            stringValue = Console.ReadLine();

            Console.WriteLine("\nВведенные значения:");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"bool: {boolValue}");
            Console.WriteLine($"char: {charValue}");
            Console.WriteLine($"string: {stringValue}");

            Console.WriteLine("\n_______________________________________\n");

            Console.WriteLine("Явное приведение");

            double dValue = 6.9;
            int iValue = (int)dValue;
            Console.WriteLine("double -> int = " + iValue);

            float fValue = 9.99f;
            int inValue = (int)fValue;
            Console.WriteLine("float -> int = " + inValue);

            long lValue = 100000;
            short sValue = (short)lValue;
            Console.WriteLine("long -> short = " + sValue);

            int bigInt = 300;
            byte byValue = (byte)bigInt;
            Console.WriteLine("int -> byte = " + byValue);

            char cValue = 'A';
            int charToInt = (int)cValue;
            Console.WriteLine("char -> int = " + charToInt);


            Console.WriteLine("\nНеявное приведение");

            int intSign = 105;
            long longSing = intSign;
            Console.WriteLine("int -> long = " + longSing);

            float floatSing = 5.5f;
            double doubleSing = floatSing;
            Console.WriteLine("float -> double = " + doubleSing);

            double dSing = 5.4;
            decimal decimalSing = (decimal)dSing;
            Console.WriteLine("double -> decimal = " + decimalSing);

            short shortSing = 100;
            int intFromSing = shortSing;
            Console.WriteLine("short -> int = " + intFromSing);

            byte byteSing = 255;
            int intFromByte = byteSing;
            Console.WriteLine("byte -> int = " + intFromByte);


            Console.WriteLine("\nприведения с помощью Convert:");

            float variableFloat = 8.99f;
            int variableInt = Convert.ToInt32(variableFloat);
            Console.WriteLine("float -> int = " + variableInt);

            bool variableBool = true;
            int variableI = Convert.ToInt32(variableBool);
            Console.WriteLine("bool -> int = " + variableI);

            string variableString = "true";
            bool variableB = Convert.ToBoolean(variableString);
            Console.WriteLine("string -> bool = " + variableB);

            Console.WriteLine("\n_______________________________________\n");

            Console.WriteLine("Упаковка и распаковка значимых типов:");

            int i = 6;
            object obj = i;
            Console.WriteLine("Упаковка: " + obj);
            int j = (int)obj;
            Console.WriteLine("Распаковка: " + j);

            Console.WriteLine("\n_______________________________________\n");

            Console.WriteLine("Неявно типизированная переменная:");

            var dateValue = DateTime.Now;
            Console.WriteLine("тип DateTime: " + dateValue);

            Console.WriteLine("\n_______________________________________\n");

            Console.WriteLine("Nullable:");

            int? nullableInt = null;
            Console.WriteLine("Начальное значение nullableInt: " + nullableInt);
            nullableInt = 30;
            Console.WriteLine("После присвоения значения: " + nullableInt);

            //var myVariable = 333; 
            //myVariable = "Hello";

            Console.WriteLine("\n_______________________________________\n");

            string string1 = "Dasha";
            string string2 = "Dasha";
            string string3 = "dasha";

            bool areEqual1 = string1 == string2;
            bool areEqual2 = string1 == string3;

            Console.WriteLine($"string1 == string2: {areEqual1}");
            Console.WriteLine($"string1 == string3: {areEqual2}");

            Console.WriteLine("\n_______________________________________\n");

            string str1 = "Hello";
            string str2 = "World";
            string str3 = "programming programm";

            string concatenated = string.Concat(str1, " ", str2);
            Console.WriteLine($"Сцепление строк: {concatenated}");

            string copied = str3;
            Console.WriteLine($"Копирование строки: {copied}");

            string substring = str3.Substring(0, 5);
            Console.WriteLine($"Выделение подстроки: {substring}");

            string[] words = str3.Split(' ');
            Console.WriteLine("Слова:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            string inserted = str3.Insert(11, " cool");
            Console.WriteLine($"Вставка подстроки: {inserted}");

            string removed = str3.Remove(12, 8);
            Console.WriteLine($"Удаление подстроки: {removed}");

            string interpolated = $"Интерполяция подстроки: {str1} {str2} is great for {str3}";
            Console.WriteLine(interpolated);

            Console.WriteLine("\n_______________________________________\n");

            string? strNull = null;
            string strEmpty = "";

            if (string.IsNullOrEmpty(strNull))
            {
                Console.WriteLine("strNull пустая или null");
            }
            if (string.IsNullOrEmpty(strEmpty))
            {
                Console.WriteLine("strEmpty пустая или null");
            }
            Console.WriteLine("Длина strEmpty равна: " + strEmpty.Length);

            Console.WriteLine("\n_______________________________________\n");
            StringBuilder StringBuil = new StringBuilder(" an old");
            StringBuil.Remove(2, 5);
            StringBuil.Insert(0, "This is");
            StringBuil.Append(" new string");
            Console.WriteLine(StringBuil);

            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
            };

            Console.WriteLine("Matrix:");
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int R = 0; R < rows; R++)
            {
                for (int J = 0; J < cols; J++)
                {
                    Console.Write($"{matrix[R, J],4}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n_______________________________________\n");

            string[] stringArray = { "aaa", "bbb", "ccc" };

            Console.Write("Содержимое массива: ");
            foreach (string stringMatrix in stringArray)
            {
                Console.Write(stringMatrix + " ");
            }

            Console.WriteLine($"\nДлина массива: {stringArray.Length}");

            Console.Write("Введите индекс элемента, который требуется изменить (от 0 до {0}):", stringArray.Length - 1);

            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < stringArray.Length)
            {
                Console.Write("Введите новое значение: ");

                var newValue = Console.ReadLine();
                stringArray[index] = newValue;

                Console.WriteLine("Обновленное содержимое массива:");
                foreach (string stringMatrix in stringArray)
                {
                    Console.WriteLine(stringMatrix);
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }

            Console.WriteLine("\n_______________________________________\n");

            double[][] jaggedArray = new double[3][];

            jaggedArray[0] = new double[2];
            jaggedArray[1] = new double[3];
            jaggedArray[2] = new double[4];

            Console.WriteLine("Введите значения для ступенчатого массива:");

            for (int ir = 0; ir < jaggedArray.Length; ir++)
            {
                Console.WriteLine($"Введите значения для строки {ir + 1} (длина {jaggedArray[ir].Length}):");
                for (int jr = 0; jr < jaggedArray[ir].Length; jr++)
                {
                    Console.Write($"Значение на позиции [{ir},{jr}]: ");
                    jaggedArray[ir][jr] = double.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Содержимое ступенчатого массива:");
            for (int ik = 0; ik < jaggedArray.Length; ik++)
            {
                Console.Write($"Строка {ik + 1}: ");
                for (int jk = 0; jk < jaggedArray[ik].Length; jk++)
                {
                    Console.Write($"{jaggedArray[ik][jk]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n_______________________________________\n");

            var stValue = "Это строка";
            Console.WriteLine($"Содержание строки: {stValue}");

            Console.WriteLine("\n_______________________________________\n");

            var stArray = new[] { "Apple", "Banana", "Cherry" };
            Console.WriteLine("Содержимое массива:");
            foreach (var item in stArray)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n_______________________________________\n");

            var myTuple = (15, "Litvunchuk", 'V', "Darya");
            Console.WriteLine($"Весь кортеж: {myTuple}");
            Console.WriteLine($"1-ый элемент: {myTuple.Item1}");
            Console.WriteLine($"3-ий элемент: {myTuple.Item3}");
            Console.WriteLine($"4-ый элемент: {myTuple.Item4}");

            var (intAlue, stringValue1, charAlue, stringValue2) = myTuple;
            Console.WriteLine($"Число: {intAlue}, Первоя строка: {stringValue1}, Символ: {charAlue}, Втоорая строка: {stringValue2}");

            var (_, _, _, secondString) = myTuple;
            Console.WriteLine($"Вторая строка (используем _): {secondString}");

            var anotherTuple = (13, "Litvunchuk", 'B', "Lar");
            Console.WriteLine($"Второй кортеж: {anotherTuple}");
            Console.WriteLine($"Кортеж равен другому кортежу: {myTuple.Equals(anotherTuple)}");

            Console.WriteLine("\n_______________________________________\n");

            (int max, int min, int sum, char firstChar) AnalyzeArray(int[] numbers, string text)
            {
                if (numbers.Length == 0)
                    throw new ArgumentException("Массив не может быть пустым");

                int max = numbers[0];
                int min = numbers[0];
                int sum = 0;

                foreach (int num in numbers)
                {
                    if (num > max) max = num;
                    if (num < min) min = num;
                    sum += num;
                }

                char firstChar = text.Length > 0 ? text[0] : '\0';
                return (max, min, sum, firstChar);
            }

            int[] numbers = { 8, 2, 9, 7, 3 };
            string text = "BSTU";

            var result = AnalyzeArray(numbers, text);

            Console.WriteLine($"Строка массва: {text}");
            Console.WriteLine($"Максимальный элемент: {result.max}, Минимальный элемент: {result.min}, Сумма: {result.sum}, Первый символ: {result.firstChar}");

            Console.WriteLine("\n_______________________________________\n");

            void CheckedOperation()
            {
                checked
                {
                    try
                    {
                        int maxValue = int.MaxValue;
                        int result = maxValue + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Checked: Переполнение.");
                    }
                }
            }

            void UncheckedOperation()
            {
                unchecked
                {
                    int maxValue = int.MaxValue;
                    int result = maxValue + 1;
                    Console.WriteLine($"Unchecked: Результат переполнения {result}");
                }
            }

            CheckedOperation();
            UncheckedOperation();
        }
    }
}
