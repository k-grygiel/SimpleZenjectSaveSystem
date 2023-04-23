using SaveLoadSystem;
using UnityEngine;
using Zenject;

namespace Examples
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private PlayerUI playerStatsUI;

        private int _currentHealth;
        private string _name = "";
        private ISaveSystem _saveSystem;

        [Inject]
        public void InitSaveSystem(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
        }

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            _name = name;
            gameObject.name = _name;
            playerStatsUI.SetName(_name);
        }

        public void DealDamage(int value)
        {
            if (_currentHealth <= 0)
                return;

            SetHealth(_currentHealth - value);
        }

        public void Heal(int amount)
        {
            if (_currentHealth >= maxHealth)
                return;

            SetHealth(_currentHealth + amount);
        }

        private void SetHealth(int health)
        {
            _currentHealth = Mathf.Clamp(health, 0, maxHealth);
            playerStatsUI.SetHealth(_currentHealth, maxHealth);
        }

        private void SaveData()
        {
            _saveSystem.Save("PlayerName", _name);
            _saveSystem.Save("PlayerHealth", _currentHealth);
        }

        private void LoadData()
        {
            if (_saveSystem.TryLoad("PlayerName", out string playerName))
                SetName(playerName);

            if (_saveSystem.TryLoad("PlayerHealth", out int playerHealth))
                SetHealth(playerHealth);
        }

        public void Save() => SaveData();

        public void Load() => LoadData();
    }
}