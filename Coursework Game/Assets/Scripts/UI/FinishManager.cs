using CourseworkGame.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CourseworkGame.UI
{
    public class FinishManager : InGamePanelManager
    {
        [SerializeField] private Button nextLevelButton;
    
        private void Start()
        {
            panel.SetActive(false);
        
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                panel.SetActive(true);
                SetTimerText();
                nextLevelButton.interactable = LevelLoadingManager.CurrentLevelIndex + 1 < SceneManager.sceneCountInBuildSettings;
            });
        }

        public void LoadNextLevel()
        {
            LevelLoadingManager.LoadLevel(LevelLoadingManager.CurrentLevelIndex + 1);
        }
    }
}
