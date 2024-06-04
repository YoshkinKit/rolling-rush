using CourseworkGame.Core;
using CourseworkGame.Saving;
using TMPro;
using UnityEngine;

namespace CourseworkGame.UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown movementTypeDropdown;
        
        private void Start()
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            movementTypeDropdown.value = (int)settings.movementType;
            
            movementTypeDropdown.onValueChanged.AddListener(ChangeMovementType);
        }

        private void ChangeMovementType(int value)
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            settings.movementType = (Movement.MovementType)value;
            SaveSystem.SavePlayerSettings(settings);
        }
    }
}