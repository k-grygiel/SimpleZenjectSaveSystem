using SaveLoadSystem.Serializers;
using Zenject;

namespace SaveLoadSystem
{
    public class LocalSaveSystem : ISaveSystem
    {
        private readonly string _savesPath;
        private ISerializer _serializer;

        public LocalSaveSystem(string savesPath)
        {
            _savesPath = savesPath;
        }

        [Inject]
        public void InitSerializer(ISerializer serializer)
        {
            _serializer = serializer;
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