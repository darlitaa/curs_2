using System;

public interface IRepository : IDisposable
{
    string BasePath { get; } // Полный путь к JSON и фотографиям
    Celebrity[] GetAllCelebrities(); // Получить весь список знаменитостей
    Celebrity? GetCelebrityById(int id); // Получить знаменитость по Id
    Celebrity[] GetCelebritiesBySurname(string surname); // Получить знаменитость по фамилии
    string? GetPhotoPathById(int id); // Получить путь для GET-запроса к фотографии
}

public record Celebrity(int Id, string Firstname, string Surname, string PhotoPath);