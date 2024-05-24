// #define DELETE_SAVES

using UnityEngine;
using UnityEngine.SceneManagement;

namespace CourseworkGame.Core
{
    public class LevelLoadingManager : MonoBehaviour
    {
        public static LevelLoadingManager Instance { get; private set; }
        public int CurrentLevelIndex { get; private set; }

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
            #if DELETE_SAVES
                Debug.Log("Deleting saves!");
                PlayerPrefs.DeleteAll();
                Debug.Log(PlayerPrefs.GetString("PlayerProgress", "No PlayerProgress"));
                Debug.Log(PlayerPrefs.GetString("Testing", "No Testing progress"));
                Debug.Log(PlayerPrefs.GetString("Testing 1", "No Testing 1 progress"));
                Debug.Log(PlayerPrefs.GetString("Main Menu", "No Main Menu progress"));
            #endif
        }

        public void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
                CurrentLevelIndex = levelIndex;
            }
            
            Debug.Log("Level index: " + levelIndex);
            Debug.Log("Current scene index: " + CurrentLevelIndex);
        }
        
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
            CurrentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            
            Debug.Log("Current scene index: " + CurrentLevelIndex);
        }
    }
}
