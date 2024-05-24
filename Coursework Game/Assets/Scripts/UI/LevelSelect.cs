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
            PlayerProgress progress = SaveSystem.LoadPlayerProgress();
            for (int i = 0; i < levelButtons.Count; i++)
            {
                levelButtons[i].interactable = i <= progress.highestLevelCompleted;
                var i1 = i;
                levelButtons[i].onClick.AddListener(() =>
                {
                    LevelLoadingManager.Instance.LoadLevel(i1 + 1);
                });
            }
        }
    }
}
