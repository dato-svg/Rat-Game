using System.IO;
using UnityEngine;

public static class JsonStorageSaver 
{
    public static void Save<T>(string key, T data)
    {
        var path = BuildPath(key);
        
    }
    
    public static T Load<T>(string key)
    {
        var path = BuildPath(key);
        if (!File.Exists(path))
        {
            return default(T);
        }

        using (var fileStream = new StreamReader(path))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<T>(json);
            return data;
        }
    }


    private static string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
