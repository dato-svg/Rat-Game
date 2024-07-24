using System;
using System.IO;
using UnityEngine;

namespace Session
{
    public class JsonStarageServis : IStorageServis
    {
        public void Save(string key, object data)
        {
            string path = BuildPath(key);
            string json = JsonUtility.ToJson(data);

            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(json);
            }
        }

        public T Load<T>(string key)
        {
            string path = BuildPath(key);

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

        private string BuildPath(string key)
        {
            return Path.Combine(Application.persistentDataPath, key);
        }
    }
}