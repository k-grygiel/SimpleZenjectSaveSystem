using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace SaveLoadSystem.Serializers
{
    public class BinarySerializer : ISerializer
    {
        private readonly string _fileExtension = "data";

        public void Serialize<T>(string savePath, string key, T data)
        {
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            using (FileStream fileStream = new FileStream($"{savePath}\\{key}.{_fileExtension}", FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, data);
            }
        }

        public bool TryDeserialize<T>(string savePath, string key, out T data)
        {
            try
            {
                using (FileStream fileStream = new FileStream($"{savePath}\\{key}.{_fileExtension}", FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    data = (T)formatter.Deserialize(fileStream);
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