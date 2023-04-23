namespace SaveLoadSystem.Serializers
{
    public interface ISerializer
    {
        public void Serialize<T>(string savePath, string key, T data);
        public bool TryDeserialize<T>(string savePath, string key, out T data);
    }
}