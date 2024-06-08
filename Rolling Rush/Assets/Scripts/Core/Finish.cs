﻿using CourseworkGame.Saving;
using CourseworkGame.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CourseworkGame.Core
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private CoinManager coinManager;
        [SerializeField] private float timeToGetCoins;
        [SerializeField] private FinishPanelManager finishPanelManager;
        public int StarsCount { get; private set; }

        private void Start()
        {
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                CalculateStars();
                SaveLevelProgress();
                SavePlayerProgress();
                finishPanelManager.SetInfoText();
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