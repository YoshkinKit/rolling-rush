using CourseworkGame.Core;
using CourseworkGame.Saving;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CourseworkGame.UI
{
    public class FinishPanelManager : InGamePanelManager
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private TextMeshProUGUI starsCountText;
        [SerializeField] private TextMeshProUGUI recordTimeText;
    
        private void Start()
        {
            panel.SetActive(false);
        
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                panel.SetActive(true);
                SetTimerText();
                SetInfoText();
                nextLevelButton.interactable = LevelLoadingManager.Instance.CurrentLevelIndex + 1 < SceneManager.sceneCountInBuildSettings;
            });
        }

        public void LoadNextLevel()
        {
            LevelLoadingManager.Instance.LoadLevel(LevelLoadingManager.Instance.CurrentLevelIndex + 1);
        }

        private void SetInfoText()
        {
            LevelProgress progress = SaveSystem.LoadLevelProgress(SceneManager.GetActiveScene().name);

            int starsCount = 0;
            if (progress.gotStarForLevelCompletion)
            {
                starsCount++;
            }
            if (progress.gotStarForCollectingCoins)
            {
                starsCount++;
            }
            if (progress.gotStarForFastCompletion)
            {
                starsCount++;
            }
            
            starsCountText.text = $"Stars: {starsCount}";
            recordTimeText.text = $"Record time: {progress.recordTime}";
            
            int minutes = Mathf.FloorToInt(progress.recordTime / 60);
            int seconds = Mathf.FloorToInt(progress.recordTime % 60);
            recordTimeText.text = $"{minutes:D2}:{seconds:D2}";
        }
    }
}
