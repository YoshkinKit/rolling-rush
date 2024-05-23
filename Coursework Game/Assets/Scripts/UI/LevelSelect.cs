using System.Collections.Generic;
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
            PlayerProgress progress = SaveSystem.LoadProgress();
            for (int i = 0; i < levelButtons.Count; i++)
            {
                levelButtons[i].interactable = i <= progress.highestLevelCompleted;
            }
        }
    }
}
