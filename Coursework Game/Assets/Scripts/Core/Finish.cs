using CourseworkGame.Saving;
using UnityEngine;

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
                int currentLevel = LevelLoadingManager.CurrentLevelIndex + 1;
                PlayerProgress progress = SaveSystem.LoadProgress();
                if (currentLevel > progress.highestLevelCompleted)
                {
                    progress.highestLevelCompleted = currentLevel;
                    SaveSystem.SaveProgress(progress);
                }
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GlobalEventManager.SendOnFinish();
            }
        }
    }
}
