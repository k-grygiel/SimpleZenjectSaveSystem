using SaveLoadSystem;
using System;
using UnityEngine;
using Zenject;

namespace Examples
{
    [Serializable]
    public struct LevelStats
    {
        public float Progress;
        public bool IsLocked;
        public int NumberOfEnemiesKilled;
    }

    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelUI levelUI;

        private ISaveSystem _saveSystem;
        private LevelStats _stats = new();

        [Inject]
        public void InitSaveSystem(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        public void AddProgress() => SetProgress(_stats.Progress + 1);

        public void KillEnemy() => SetEnemyCounter(_stats.NumberOfEnemiesKilled + 1);

        public void LockLevel(bool value) => SetLockState(value);

        private void SetProgress(float progress)
        {
            _stats.Progress = progress;
            levelUI.SetProgress(_stats.Progress);
        }

        private void SetEnemyCounter(int numberOfEnemiesKilled)
        {
            _stats.NumberOfEnemiesKilled = numberOfEnemiesKilled;
            levelUI.SetNumberOfEnemiesKilled(_stats.NumberOfEnemiesKilled);
        }

        private void SetLockState(bool value)
        {
            _stats.IsLocked = value;
            levelUI.SetLockState(_stats.IsLocked);
        }

        private void LoadLevel()
        {
            if (!_saveSystem.TryLoad("LevelStats", out _stats))
                return;

            SetLockState(_stats.IsLocked);
            SetEnemyCounter(_stats.NumberOfEnemiesKilled);
            SetProgress(_stats.Progress);
        }

        private void SaveLevel()
        {
            _saveSystem.Save("LevelStats", _stats);
        }

        public void Save() => SaveLevel();

        public void Load() => LoadLevel();
    }
}