using TMPro;
using UnityEngine;

namespace Examples
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameLabel;
        [SerializeField] private TextMeshProUGUI healthLabel;

        public void SetName(string name)
        {
            nameLabel.text = name;
        }

        public void SetHealth(int health, int maxHealth)
        {
            healthLabel.text = $"{health}/{maxHealth}";
        }
    }
}