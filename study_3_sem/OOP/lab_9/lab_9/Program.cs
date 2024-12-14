using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace lab_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Image<int> image1 = new Image<int>();
            Image<int> image2 = new Image<int>();
            Image<int> image3 = new Image<int>();
            Image<int> image4 = new Image<int>();
            HashSet<Image<int>> set = new() {image1, image2, image3, image4 };

            // task 2
            var employees = new List<string> { "Tom", "Sam", "Bob", "Nik", "Pasha", "Slava" };

            LinkedList<string> people = new LinkedList<string>(employees);
            foreach (string person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("------------------");

            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                people.RemoveFirst();
            }

            people.AddFirst("Mark");
            people.AddLast("Oleg");
            LinkedListNode<string>? current = people.FindLast("Nik");
            people.AddAfter(current, "Anna");
            people.AddBefore(current, "Masha");

            foreach (string person in people)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("------------------");

            HashSet<string> set2 = new HashSet<string>() {
            "Mama", "Papa", "Son"
        };

            set2.UnionWith(people);

            foreach (string person in set2)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine("------------------");
            string searchValue = "Mama";

            bool containsValue = set2.Contains(searchValue);
            Console.WriteLine(containsValue);


            Console.WriteLine("------------------");
            // Task 3

            var MyColletion = new ObservableCollection<Image<int>>();

            MyColletion.CollectionChanged += MyCollection_onChange; // подписываемся на изменения коллекции 

            MyColletion.Add(image1);

            MyColletion.RemoveAt(0);





            Console.ReadKey();
        }

        private static void MyCollection_onChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Add element in collection MyCollection");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Delete element in collection MyCollection");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Console.WriteLine("Change element in collection MyCollection");
                    break;
            }
        }
    }
}
