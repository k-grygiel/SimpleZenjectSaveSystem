using SaveLoadSystem;
using SaveLoadSystem.Serializers;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SaveSystemInstaller", menuName = "Installers/SaveSystemInstaller")]
public class SaveSystemInstaller : ScriptableObjectInstaller<SaveSystemInstaller>
{
    [SerializeField] private ScriptableLocalJsonSaveSystem scriptableJsonSaveSystem;
    [SerializeField] private string savePath;

    public override void InstallBindings()
    {
        ////inject scriptable object json save system
        Container.Bind<ISaveSystem>().FromInstance(scriptableJsonSaveSystem).AsSingle().NonLazy();
        scriptableJsonSaveSystem.SetSavePath(savePath);

        ////inject json save system instance
        //Container.Bind<string>().FromInstance(savePath);
        //Container.Bind<ISaveSystem>().To<LocalSaveSystem>().AsSingle().NonLazy();
        //Container.Bind<ISerializer>().To<JsonSerializer>().AsSingle().NonLazy();

        ////inject binary save system instance
        //Container.Bind<string>().FromInstance(savePath);
        //Container.Bind<ISaveSystem>().To<LocalSaveSystem>().AsSingle().NonLazy();
        //Container.Bind<ISerializer>().To<BinarySerializer>().AsSingle().NonLazy();
    }
}