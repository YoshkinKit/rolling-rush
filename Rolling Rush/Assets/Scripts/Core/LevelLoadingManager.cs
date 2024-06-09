using UnityEngine;
using UnityEngine.SceneManagement;

namespace CourseworkGame.Core
{
    public class LevelLoadingManager : MonoBehaviour
    {
        public static LevelLoadingManager Instance { get; private set; }
        public int CurrentLevelIndex { get; private set; }
        public int AttemptsCount { get; set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
                CurrentLevelIndex = levelIndex;
            }
        }
        
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
            CurrentLevelIndex = SceneManager.GetSceneByName(levelName).buildIndex;
        }
    }
}
