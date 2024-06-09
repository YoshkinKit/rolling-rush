using RollingRush.Saving;
using RollingRush.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RollingRush.Core
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private CoinManager coinManager;
        [SerializeField] private float timeToGetCoins;

        private void Awake()
        {
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                SaveLevelProgress();
                SavePlayerProgress();
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GlobalEventManager.SendOnFinish();
            }
        }

        private void SavePlayerProgress()
        {
            int currentLevel = LevelLoadingManager.Instance.CurrentLevelIndex + 1;
            PlayerProgress progress = SaveSystem.LoadPlayerProgress();
            if (currentLevel > progress.highestLevelCompleted)
            {
                progress.highestLevelCompleted = currentLevel;
            }

            progress.coinsCount += coinManager.CurrentCoinCount;
            SaveSystem.SavePlayerProgress(progress);
        }

        private void SaveLevelProgress()
        {
            string levelName = SceneManager.GetActiveScene().name;
            LevelProgress progress = SaveSystem.LoadLevelProgress(levelName);
            
            if (timer.LevelTime < progress.recordTime)
            {
                progress.recordTime = timer.LevelTime;
            }

            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            if (!progress.gotStarForLevelCompletion)
            {
                progress.gotStarForLevelCompletion = true;
                playerProgress.starsCount++;
            }
            
            if (coinManager.RemainingCoins.Count == 0 && !progress.gotStarForCollectingCoins)
            {
                progress.gotStarForCollectingCoins = true;
                playerProgress.starsCount++;
            }
            
            if (timer.LevelTime < timeToGetCoins && !progress.gotStarForFastCompletion)
            {
                progress.gotStarForFastCompletion = true;
                playerProgress.starsCount++;
            }

            SaveSystem.SavePlayerProgress(playerProgress);
            SaveSystem.SaveLevelProgress(progress, levelName);
        }
    }
}
