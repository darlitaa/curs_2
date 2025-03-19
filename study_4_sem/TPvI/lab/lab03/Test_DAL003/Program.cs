using System;
using Newtonsoft.Json;

class Program
{
    private static void Main(string[] args)
    {
        using (IRepository repository = Repository.Create(@"D:\curs_2\study_4_sem\ТПвИ\lab\lab03\ASPA\Test_DAL003\Celebrities"))
        {
            foreach (Celebrity celebrity in repository.GetAllCelebrities())
            {
                Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                  $"Surname = {celebrity.Surname}, Photo Path = {celebrity.PhotoPath}");
            }
            Console.WriteLine();

            Celebrity? celebrity1 = repository.GetCelebrityById(1);
            if (celebrity1 != null)
            {
                Console.WriteLine($"Id = {celebrity1.Id}, Firstname = {celebrity1.Firstname}, " +
                                  $"Surname = {celebrity1.Surname}, Photo Path = {celebrity1.PhotoPath}");
            }

            Celebrity? celebrity3 = repository.GetCelebrityById(3);
            if (celebrity3 != null)
            {
                Console.WriteLine($"Id = {celebrity3.Id}, Firstname = {celebrity3.Firstname}, " +
                                  $"Surname = {celebrity3.Surname}, Photo Path = {celebrity3.PhotoPath}");
            }

            Celebrity? celebrity7 = repository.GetCelebrityById(7);
            if (celebrity7 != null)
            {
                Console.WriteLine($"Id = {celebrity7.Id}, Firstname = {celebrity7.Firstname}, " +
                                  $"Surname = {celebrity7.Surname}, PhotoPath = {celebrity7.PhotoPath}");
            }

            Celebrity? celebrity222 = repository.GetCelebrityById(222);
            if (celebrity222 != null)
            {
                Console.WriteLine($"Id = {celebrity222.Id}, Firstname = {celebrity222.Firstname}, " +
                                  $"Surname = {celebrity222.Surname}, PhotoPath = {celebrity222.PhotoPath}");
            }
            else Console.WriteLine("Not Found 222.");
            

            foreach (Celebrity celebrity in repository.GetCelebritiesBySurname("Chomsky"))
            {
                Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                  $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath}");
            }

            foreach (Celebrity celebrity in repository.GetCelebritiesBySurname("Knuth"))
            {
                Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                  $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath}");
            }

            foreach (Celebrity celebrity in repository.GetCelebritiesBySurname("XXXX"))
            {
                Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                  $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath}");
            }

            Console.WriteLine($"PhotoPathbyID 4: {repository.GetPhotoPathById(4)}");
            Console.WriteLine($"PhotoPathbyID 6: {repository.GetPhotoPathById(6)}");
            Console.WriteLine($"PhotoPathbyID 222: {repository.GetPhotoPathById(222)}");
        }
    }
}