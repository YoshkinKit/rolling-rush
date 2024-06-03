using System.Collections.Generic;
using CourseworkGame.Core;
using CourseworkGame.Saving;
using UnityEngine;
using UnityEngine.UI;

namespace CourseworkGame.UI
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField] private List<Button> levelButtons;

        private void Start()
        {
            PlayerProgress playerProgress = SaveSystem.LoadPlayerProgress();
            
            for (int i = 0; i < levelButtons.Count; i++)
            {
                levelButtons[i].interactable = i < playerProgress.highestLevelCompleted;
                
                var stars = levelButtons[i].transform.GetChild(1);
                var levelProgress = SaveSystem.LoadLevelProgress($"Testing {i + 1}");
                Debug.Log($"Testing {i + 1}");
                Debug.Log(levelProgress.gotStarForLevelCompletion);
                Debug.Log(levelProgress.gotStarForCollectingCoins);
                Debug.Log(levelProgress.gotStarForFastCompletion);
                SetStars(levelProgress, stars);
                
                var i1 = i;
                levelButtons[i].onClick.AddListener(() =>
                {
                    LevelLoadingManager.Instance.LoadLevel(i1 + 1);
                });
            }
        }

        private static void SetStars(LevelProgress levelProgress, Transform stars)
        {
            var starsCount = new[] { levelProgress.gotStarForLevelCompletion, levelProgress.gotStarForCollectingCoins, levelProgress.gotStarForFastCompletion};
            for (int j = 0; j < 3; j++)
            {
                if (starsCount[j])
                    stars.GetChild(j).gameObject.SetActive(true);
                else
                    stars.GetChild(j + 3).gameObject.SetActive(true);
            }
        }

        private void ActivateStar(GameObject star, bool isGotStar)
        {
            star.SetActive(isGotStar);
        }
    }
}
