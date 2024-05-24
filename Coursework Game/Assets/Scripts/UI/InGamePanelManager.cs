using CourseworkGame.Core;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            // LevelLoadingManager.LoadLevel(SceneManager.GetSceneByName("Main Menu").buildIndex);
            LevelLoadingManager.Instance.LoadLevel(0); // Первая сцена всегда Main Menu
        }

        protected void SetTimerText()
        {
            int minutes = Mathf.FloorToInt(timer.LevelTime / 60);
            int seconds = Mathf.FloorToInt(timer.LevelTime % 60);

            timerText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}