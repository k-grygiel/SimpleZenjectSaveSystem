using SaveLoadSystem;
using UnityEngine;

public class CloudSaveSystem : ISaveSystem
{
    //TODO
    public void Save<T>(string key, T value)
    {
        Debug.Log($"Cloud save: {key}");
    }

    public bool TryLoad<T>(string key, out T data)
    {
        Debug.Log($"Cloud load: {key}");
        data = default(T);
        return true;
    }
}
