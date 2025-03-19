using Newtonsoft.Json;

public class Repository : IRepository
{
    private readonly string _directory;
    private readonly Celebrity[] _celebrities;

    public static string JSONFileName => "Celebrities.json";

    public Repository(string directory)
    {
        _directory = directory;
        _celebrities = LoadCelebrities();
    }

    private Celebrity[] LoadCelebrities()
    {
        var jsonFilePath = Path.Combine(_directory, JSONFileName);
        if (!File.Exists(jsonFilePath))
            throw new FileNotFoundException("JSON file not found.", jsonFilePath);

        var json = File.ReadAllText(jsonFilePath);
        return JsonConvert.DeserializeObject<Celebrity[]>(json) ?? Array.Empty<Celebrity>();
    }

    public string BasePath => _directory;

    public Celebrity[] GetAllCelebrities() => _celebrities;

    public Celebrity? GetCelebrityById(int id) => _celebrities.FirstOrDefault(c => c.Id == id);

    public Celebrity[] GetCelebritiesBySurname(string surname) =>
        _celebrities.Where(c => string.Equals(c.Surname, surname, StringComparison.OrdinalIgnoreCase)).ToArray();

    public string? GetPhotoPathById(int id) => GetCelebrityById(id)?.PhotoPath;

    public void Dispose()
    {

    }
    
    public static Repository Create(string directory)
    {
        return new Repository(directory);
    }
}