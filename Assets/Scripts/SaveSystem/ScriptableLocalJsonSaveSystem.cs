using SaveLoadSystem.Serializers;
using UnityEngine;

namespace SaveLoadSystem
{
    [CreateAssetMenu(fileName = "ScriptableSaveSystem", menuName = "SaveSystem/ScriptableLocalJsonSaveSystem")]
    public class ScriptableLocalJsonSaveSystem : ScriptableObject, ISaveSystem
    {
        private string _savesPath;
        private ISerializer _serializer = new JsonSerializer();

        public void SetSavePath(string savePath)
        {
            _savesPath = savePath;
        }

        public void Save<T>(string key, T value)
        {
            _serializer.Serialize(_savesPath, key, value);
        }

        public bool TryLoad<T>(string key, out T data)
        {
            bool isValid = _serializer.TryDeserialize(_savesPath, key, out T deserializedData);

            data = isValid ? deserializedData : default;
            return isValid;
        }
    }
}