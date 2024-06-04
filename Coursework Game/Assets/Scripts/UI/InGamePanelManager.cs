using CourseworkGame.Core;
using TMPro;
using UnityEngine;

namespace CourseworkGame.UI
{
    public class InGamePanelManager : MonoBehaviour
    {
        [SerializeField] protected GameObject panel;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private Timer timer;
    
        public virtual void ResetLevel()
        {
            panel.SetActive(false);
            LevelLoadingManager.Instance.LoadLevel(LevelLoadingManager.Instance.CurrentLevelIndex);
        }
    
        public void BackToMainMenu()
        {
            Time.timeScale = 1f;
            LevelLoadingManager.Instance.LoadLevel("Main Menu");
        }

        protected void SetTimerText()
        {
            int minutes = Mathf.FloorToInt(timer.LevelTime / 60);
            int seconds = Mathf.FloorToInt(timer.LevelTime % 60);

            timerText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
