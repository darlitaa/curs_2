using System.Diagnostics;
using System.Security.Cryptography;

namespace lab_6
{
    class Program
    {
        static void Main()
        {
            //var Medovik = new Cake("BelCake", 22.22, "01.10.2024", 10.5, 1.7, 20);
            //var Alenka = new Candy("BelCandy", 1.2, "02.12.2025", "с топпингом");
            //var Roses = new Flowers("Kvetka", 40.2, "девушка", 21);
            //var Rolex = new Watch("Rolex", 999.9, "мужчина", "хронографический");

            //Medovik.GetExpiration();
            //((IExpiration)Medovik).GetExpiration();
            //Console.WriteLine();


            //if (Medovik is IExpiration)
            //{
            //    Console.WriteLine("true (Medovik is IExpiration)");
            //}
            //else
            //{
            //    Console.WriteLine("false (Medovik is IExpiration)");
            //}
            //Console.WriteLine();


            //IExpiration medovik = Medovik;
            //if (medovik as Cake != null)
            //{
            //    Console.WriteLine($"({medovik}) medovik as Cake\n");
            //}
            //Console.WriteLine("-----------------------------\n");


            //Printer Printer = new Printer();
            //Product[] array = new Product[] { Alenka, Roses, Rolex };

            //foreach (var element in array)
            //{
            //    Printer.IAmPrinting(element);
            //}


            try
            {
                Cake Medovik = new Cake("BelCake", 22.22, "01.10.2024", 10.5, 1.7, 20);
            }
            catch (InvalidCakeException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            try
            {
                Flowers Roses = new Flowers("Kvetka", 40.2, "девушка", 21);
            }
            catch (InvalidFlowersException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", exc.TargetSite);
                throw;
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            try
            {
                var p = 64;
                var c = 0;
                if (c == 0) throw new DivideByZeroException("нельзя делить на ноль");
                else p /= c;
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            var flag = true;
            try
            {
                var ch = Convert.ToChar(flag);
                Console.WriteLine("Успешно преобразовано");
            }
            catch (InvalidCastException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            int[] arr = { 1, 2, 3, 4, 5 };
            try
            {
                var length = 10;
                if (length > arr.Length) throw new IndexOutOfRangeException("с этой длиной массив выйдет за пределы диапазона");
                for (var i = 0; i < length; i++)
                    arr[i] += arr[i];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {ex.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", ex.TargetSite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошло неожиданное исключение");
                Console.WriteLine($"Тип: {ex.GetType()}");
                Console.WriteLine($"Сообщение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            try
            {
                A();
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения исключения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("блок finally\n\n");
            }



            Debug.Assert(1 == 1, "Условие не подтвердилось");
            Console.WriteLine("Условие успешно выполнено");
            Console.WriteLine("\n");

            Debug.Assert(1 == 3, "Условие не подтвердилось");
            Console.WriteLine("Условие успешно выполнено");

        }

        public static void A()
        {
            try
            {
                B();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Обработано в MethodA:");
                Console.WriteLine($"Сообщение: {ex.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine("Блок finally в MethodA\n");
            }
        }

        public static void B()
        {
            var p = 64;
            var c = 0; 
            if (c == 0) throw new DivideByZeroException("нельзя делить на ноль");
            else p /= c; 
        }
    }
}
