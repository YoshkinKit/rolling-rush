using CourseworkGame.Core;
using CourseworkGame.Saving;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CourseworkGame.UI
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown movementTypeDropdown;
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Toggle sfxToggle;
        [SerializeField] private AudioMixerGroup mixer;
        
        private void Start()
        {
            movementTypeDropdown.onValueChanged.AddListener(ChangeMovementType);
            masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
            musicToggle.onValueChanged.AddListener(ToggleMusic);
            sfxToggle.onValueChanged.AddListener(ToggleSFX);
            
            SetStartSettingsValues();
        }

        private void SetStartSettingsValues()
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            
            movementTypeDropdown.value = (int)settings.movementType;
            masterVolumeSlider.value = settings.masterVolume;
            musicToggle.isOn = settings.musicIsOn;
            sfxToggle.isOn = settings.sfxIsOn;
        }

        private void ChangeMovementType(int value)
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            settings.movementType = (Movement.MovementType)value;
            SaveSystem.SavePlayerSettings(settings);
        }

        private void ChangeMasterVolume(float volume)
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            settings.masterVolume = volume;
            mixer.audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
            SaveSystem.SavePlayerSettings(settings);
        }

        private void ToggleMusic(bool isOn)
        {
            ToggleSound("Music", isOn);
        }

        private void ToggleSFX(bool isOn)
        {
            ToggleSound("SFX", isOn);
        }

        private void ToggleSound(string soundName, bool isOn)
        {
            PlayerSettings settings = SaveSystem.LoadPlayerSettings();
            switch (soundName)
            {
                case "Music":
                    settings.musicIsOn = isOn;
                    break;
                case "SFX":
                    settings.sfxIsOn = isOn;
                    break;
            }
            mixer.audioMixer.SetFloat(soundName, isOn ? 0f : -80f);
            SaveSystem.SavePlayerSettings(settings);
        }
    }
}