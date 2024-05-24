using CourseworkGame.Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CourseworkGame.Core
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private CoinManager coinManager;
        [SerializeField] private float timeToGetCoins;
        public int StarsCount { get; private set; }

        private void Start()
        {
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                CalculateStars();
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

        private void CalculateStars()
        {
            StarsCount++;
            if (coinManager.RemainingCoins.Count == 0)
            {
                StarsCount++;
            }

            if (timer.LevelTime < timeToGetCoins)
            {
                StarsCount++;
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
            if (!progress.gotCoinForLevelCompletion)
            {
                progress.gotCoinForLevelCompletion = true;
                playerProgress.starsCount++;
            }
            
            if (coinManager.RemainingCoins.Count == 0 && !progress.gotCoinForCollectingCoins)
            {
                progress.gotCoinForCollectingCoins = true;
                playerProgress.starsCount++;
            }
            
            if (timer.LevelTime < timeToGetCoins && !progress.gotCoinForFastCompletion)
            {
                progress.gotCoinForFastCompletion = true;
                playerProgress.starsCount++;
            }

            SaveSystem.SavePlayerProgress(playerProgress);
            SaveSystem.SaveLevelProgress(progress, levelName);
        }
    }
}
