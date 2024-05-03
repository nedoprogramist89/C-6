using Newtonsoft.Json;
using System.IO;
using System.Xml;

public class DataAccessService
{
    private readonly string _filePath;

    public DataAccessService(string filePath)
    {
        _filePath = filePath;
    }

    public void SaveData<T>(T data)
    {
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(_filePath, jsonData);
    }

    public T LoadData<T>()
    {
        if (!File.Exists(_filePath))
        {
            return default;
        }

        string jsonData = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
