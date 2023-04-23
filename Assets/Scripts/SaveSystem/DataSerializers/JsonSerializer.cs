using Newtonsoft.Json;
using System.IO;
using UnityEngine;

namespace SaveLoadSystem.Serializers
{
    public class JsonSerializer : ISerializer
    {
        private readonly string _fileExtension = "json";

        public void Serialize<T>(string savePath, string key, T data)
        {
            var json = JsonConvert.SerializeObject(data);
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            using (StreamWriter writer = new StreamWriter($"{savePath}\\{key}.{_fileExtension}"))
            {
                writer.Write(json);
            }
        }

        public bool TryDeserialize<T>(string savePath, string key, out T data)
        {
            try
            {
                using (StreamReader reader = new StreamReader($"{savePath}\\{key}.{_fileExtension}"))
                {
                    var json = reader.ReadToEnd();
                    data = JsonConvert.DeserializeObject<T>(json);
                    return true;
                }
            }
            catch (System.Exception exception)
            {
                Debug.Log(exception.Message);
                data = default(T);
                return false;
            }
        }
    }
}