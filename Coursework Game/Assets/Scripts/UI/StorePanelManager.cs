using CourseworkGame.Saving;
using TMPro;
using UnityEngine;

namespace CourseworkGame.UI
{
    public class StorePanelManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI starsText;

        public void SetCoinsText()
        {
            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            coinsText.text = $"{playerProgress.coinsCount}";
        }
        
        public void SetStarsText()
        {
            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            starsText.text = $"{playerProgress.starsCount}";
        }
    }
}
