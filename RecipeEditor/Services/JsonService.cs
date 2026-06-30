using System.Text.Json;
using RecipeEditor.Models;

namespace RecipeEditor.Services;

public class JsonService
{
    private readonly string _path;

    public JsonService(string path)
    {
        _path = path;
    }

    public RecipeDatabase Load()
    {

        if (!File.Exists(_path))
            throw new FileNotFoundException("Fandt ikke recipes.json", _path);

        var json = File.ReadAllText(_path);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        var result = JsonSerializer.Deserialize<RecipeDatabase>(json, options);

        return result ?? new RecipeDatabase();
    }

    public void Save(RecipeDatabase data)
    {
        data.Version++;

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        var json = JsonSerializer.Serialize(data, options);

        File.WriteAllText(_path, json);
    }
}