using TMPro;
using UnityEngine;

namespace Examples
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI progressLabel;
        [SerializeField] private TextMeshProUGUI lockStateLabel;
        [SerializeField] private TextMeshProUGUI numberOfEnemiesKilledLabel;

        public void SetProgress(float progress)
        {
            progressLabel.text = progress.ToString();
        }

        public void SetLockState(bool value)
        {
            lockStateLabel.text = value ? "Locked" : "Unlocked";
        }

        public void SetNumberOfEnemiesKilled(int number)
        {
            numberOfEnemiesKilledLabel.text = number.ToString();
        }
    }
}