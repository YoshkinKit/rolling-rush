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
        [SerializeField] private TextMeshProUGUI recordTimeText;
        [SerializeField] private Transform stars;
    
        private void Start()
        {
            panel.SetActive(false);

            GlobalEventManager.OnFinish.AddListener(() =>
            {
                panel.SetActive(true);
                nextLevelButton.interactable = LevelLoadingManager.Instance.CurrentLevelIndex + 1 < SceneManager.sceneCountInBuildSettings;
            });
        }

        public void LoadNextLevel()
        {
            LevelLoadingManager.Instance.LoadLevel(LevelLoadingManager.Instance.CurrentLevelIndex + 1);
        }

        public void SetInfoText()
        {
            LevelProgress progress = SaveSystem.LoadLevelProgress(SceneManager.GetActiveScene().name);

            SetStars(progress);
            
            int minutes = Mathf.FloorToInt(progress.recordTime / 60);
            int seconds = Mathf.FloorToInt(progress.recordTime % 60);
            recordTimeText.text = $"Record time: {minutes:D2}:{seconds:D2}";
        }

        private void SetStars(LevelProgress progress)
        {
            var starsFlags = new[] { progress.gotStarForLevelCompletion, progress.gotStarForCollectingCoins, progress.gotStarForFastCompletion};
            
            for (int j = 0; j < 3; j++)
            {
                if (starsFlags[j])
                    stars.GetChild(j).gameObject.SetActive(true);
                else
                    stars.GetChild(j + 3).gameObject.SetActive(true);
            }
        }
    }
}
