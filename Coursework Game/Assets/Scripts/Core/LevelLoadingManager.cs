using UnityEngine;
using UnityEngine.SceneManagement;

namespace CourseworkGame.Core
{
    public class LevelLoadingManager : MonoBehaviour
    {
        public static LevelLoadingManager Instance { get; private set; }
        public static int CurrentLevelIndex { get; private set; }

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

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex > 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(levelIndex);
                CurrentLevelIndex = levelIndex;
            }
        }
    }
}
