using System;

namespace lab_3
{
    public class Node
    {
        public int Data;
        public Node Next;
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    public class List
    {
        public Node head = null;
        public void Add(int date)
        {
            Node newNode = new Node(date);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

        public static List operator +(List list1, List list2)
        {
            List newList = new List();
            Node current;

            current = list1.head;
            while(current != null)
            {
                newList.Add(current.Data);
                current = current.Next;
            }
            current = list2.head;
            while (current != null)
            {
                newList.Add(current.Data);
                current = current.Next;
            }
            return newList;
        }

        public static List operator --(List list)
        {
            if (list.head == null) return list;

            list.head = list.head.Next;
            return list;
        }

        public static bool operator ==(List list1, List list2)
        {
            Node current1 = list1.head;
            Node current2 = list2.head;

            while (current1 != null && current2 != null)
            {
                if (current1.Data != current2.Data)
                {
                    return false;
                }
                current1 = current1.Next;
                current2 = current2.Next;
            }
            return current1 == null && current2 == null;
        }
        public static bool operator !=(List list1, List list2)
        {
            return !(list1 == list2);
        }

        public static implicit operator bool(List list)
        {
            return list.head == null;
        }

        public class Production
        {
            Guid Id { get; set; }
            string organizationName { get; set; }

            public Production(string name)
            {
                Id = Guid.NewGuid();
                organizationName = name;
            }
        }
        public class Developer
        {
            string fullName { get; set; }
            Guid Id { get; set; }
            string department { get; set; }

            public Developer(string name, string dep)
            {
                fullName = name;
                Id = Guid.NewGuid();
                department = dep;
            }
        }
    }

    public static class StatisticOperation
    {
        public static int GetSum(List list)
        {
            Node current = list.head;
            int sum = 0;
            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }
            return sum;
        }

        public static int GetDifferenceMinMax(List list)
        {
            Node current = list.head;
            int max = current.Data;
            int min = current.Data;
            while (current != null)
            {
                if (max < current.Data) max = current.Data;
                if (min > current.Data) min = current.Data;
                current = current.Next;
            }
            return max - min;
        }

        public static int NumberOfElements(List list)
        {
            Node current = list.head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public static int? LastNumber(this string str)
        {
            var parts = str.Split(new[] { ' ' });
            for (int i = parts.Length - 1; i >= 0; i--)
            {
                if (int.TryParse(parts[i], out var number))
                {
                    return number;
                }
            }
            return null;
        }

        public static bool Remove(this List list, int date)
        {
            if (list.head == null) return false;

            if (list.head.Data == date)
            {
                list.head = list.head.Next;
                return true;
            }

            Node current = list.head;
            while (current.Next != null)
            {
                if (current.Next.Data == date)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
    class Program
    {
        static void Main()
        {
            List list1 = new List();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);
            list1.Add(6);

            List list2 = new List();
            list2.Add(7);
            list2.Add(8);
            list2.Add(9);

            Console.Write("Первый список: ");
            list1.Print();
            Console.Write("Второй список: ");
            list2.Print();
            Console.WriteLine();


            Console.WriteLine("\tПерегруженные операторы: ");

            Console.Write("Объеденение двух списков: ");
            List combinedList = list1 + list2;
            combinedList.Print();

            Console.Write("Удаление элемента из начала списка: ");
            --list1;
            list1.Print();

            bool areEqual = list1 == list2;
            Console.WriteLine($"Проверка равны ли списки: {areEqual}");

            bool isEmpty = new List();
            Console.WriteLine($"Проверка пуст ли список: {isEmpty}");
            Console.WriteLine();

            Console.WriteLine("\tМетоды расширения: ");

            string str = "74 42 83 23 88";
            int? lastNumber = StatisticOperation.LastNumber(str);
            Console.WriteLine($"Последнее число в строке: {lastNumber}");

            list1.Remove(5);
            Console.Write($"Убрали элемент 5 из односвязного списка: ");
            list1.Print();
            Console.WriteLine();


            List.Production myProduction = new List.Production("BSTU");
            List.Developer myDeveloper = new List.Developer("Litvinchuk Daria Valeryevna", "FIT");

            Console.WriteLine("\tMетоды для работы с классом: ");
            Console.WriteLine($"Сумма элементов cписка: {StatisticOperation.GetSum(list2)}");
            Console.WriteLine($"Pазница между максимальным и минимальным элементов cписка: {StatisticOperation.GetDifferenceMinMax(list2)}");
            Console.WriteLine($"Количество элементов в списке: {StatisticOperation.NumberOfElements(list2)}");
        }
    }
}