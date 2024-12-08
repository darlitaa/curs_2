using lab_8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_08 
{
    public class Program
    {
        static void Main()
        {
            ProgrammerList programmerList = new ProgrammerList();

            Programmer alice = new Programmer("Alice");
            Programmer dasha = new Programmer("Dasha");
            Programmer igore = new Programmer("Igore");
            Programmer maks = new Programmer("Maks");
            Programmer ola = new Programmer("Ola");

            programmerList.Add(alice);
            programmerList.Add(dasha);
            programmerList.Add(igore);
            programmerList.Add(maks);
            programmerList.Add(ola);

            alice.Remove += (sender, e) => programmerList.RemoveFirst();
            ola.Remove += (sender, e) => programmerList.RemoveLast();

            dasha.Mutation += (sender, e) => programmerList.RandomMutate();
            igore.Mutation += (sender, e) => programmerList.RandomMutate();
            maks.Mutation += (sender, e) => programmerList.RandomMutate();

            Console.WriteLine("Состояние списка программистов:");
            Console.WriteLine($"{programmerList.ToString()}\n");


            ola.OnRemove();
            dasha.OnMutation();
            alice.OnRemove();

            Console.WriteLine("\nСостояние списка программистов после событий:");
            Console.WriteLine(programmerList.ToString());



            string MyString = "Счастье - это жизнь!";
            Console.WriteLine($"\n\n\nИсходная строка: {MyString}\n");

            Func<string, string> operateText;
            string result;

            operateText = Str.RemoveSeparators;
            result = operateText(MyString);
            Console.WriteLine($"Строка после удаления сепараторов: {result}");

            operateText = Str.RemoveSpaces;
            result = operateText(result);
            Console.WriteLine($"Строка после удаления пробелов: {result}");

            operateText = Str.UpperSymbols;
            result = operateText(result);
            Console.WriteLine($"Строка после привдениия строки в верхнему регистру: {result}");

            operateText = Str.AddSymbols;
            result = operateText(result);
            Console.WriteLine($"Строка после добавления символов: {result}\n");

            Action<string> GetSize = Str.CountSymbols;
            GetSize(result);

            Predicate<string> HasChanged = text => text.Length < MyString.Length;
            Console.WriteLine(HasChanged(result) ? "Строка изменилась" : "Строка не изменилась");
        }
    }
}