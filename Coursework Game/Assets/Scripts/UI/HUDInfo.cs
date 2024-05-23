using CourseworkGame.Core;
using TMPro;
using UnityEngine;

namespace CourseworkGame.UI
{
    public class HUDInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI coinsLeftText;
        [SerializeField] private CoinManager coinManager;
        [SerializeField] private Timer timer;
    
        private void Awake()
        {
            GlobalEventManager.OnCoinPickup.AddListener((coin) =>
            {
                coinsLeftText.text = $"Coins left: {coinManager.Coins.Count}";
            });
        }

        private void Start()
        {
            timerText.text = "00:00";
            coinsLeftText.text = $"Coins left: {coinManager.Coins.Count}";
        }

        private void Update()
        {
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            int minutes = Mathf.FloorToInt(timer.LevelTime / 60);
            int seconds = Mathf.FloorToInt(timer.LevelTime % 60);

            timerText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
