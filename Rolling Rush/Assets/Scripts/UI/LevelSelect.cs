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
            var playerProgress = SaveSystem.LoadPlayerProgress();
            
            for (int i = 0; i < levelButtons.Count; i++)
            {
                SetStars(i);
                SetButton(i, playerProgress.highestLevelCompleted);
            }
        }

        private void SetButton(int index, int highestLevelCompleted)
        {
            levelButtons[index].interactable = index < highestLevelCompleted;
            levelButtons[index].onClick.AddListener(() =>
            {
                LevelLoadingManager.Instance.LoadLevel(index + 1);
            });
        }

        private void SetStars(int index)
        {
            var stars = levelButtons[index].transform.GetChild(1);
            var levelProgress = SaveSystem.LoadLevelProgress($"Level {index + 1}");
            var starsFlags = new[] { levelProgress.gotStarForLevelCompletion, levelProgress.gotStarForCollectingCoins, levelProgress.gotStarForFastCompletion};
            
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
