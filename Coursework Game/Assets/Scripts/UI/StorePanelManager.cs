using CourseworkGame.Saving;
using TMPro;
using UnityEngine;

namespace CourseworkGame
{
    public class StorePanelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI starsText;

        public void SetCoinsText()
        {
            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            coinsText.text = $"Coins: {playerProgress.coinsCount}";
        }
        
        public void SetStarsText()
        {
            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            starsText.text = $"Stars: {playerProgress.starsCount}";
        }
    }
}
