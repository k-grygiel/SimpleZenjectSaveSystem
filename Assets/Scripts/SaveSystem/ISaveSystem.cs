namespace SaveLoadSystem
{
    public interface ISaveSystem
    {
        public void Save<T>(string key, T value);
        public bool TryLoad<T>(string key, out T data);
    }
}