using UnityEngine;

namespace CourseworkGame.Saving
{
    public static class SaveSystem
    {
        public static void SavePlayerProgress(PlayerProgress progress)
        {
            string json = JsonUtility.ToJson(progress);
            PlayerPrefs.SetString("PlayerProgress", json);
            PlayerPrefs.Save();
        }

        public static PlayerProgress LoadPlayerProgress()
        {
            if (PlayerPrefs.HasKey("PlayerProgress"))
            {
                string json = PlayerPrefs.GetString("PlayerProgress");
                return JsonUtility.FromJson<PlayerProgress>(json);
            }
            return new PlayerProgress();
        }
        
        public static void SaveLevelProgress(LevelProgress progress, string levelName)
        {
            string json = JsonUtility.ToJson(progress);
            PlayerPrefs.SetString(levelName, json);
            PlayerPrefs.Save();
        }

        public static LevelProgress LoadLevelProgress(string levelName)
        {
            if (PlayerPrefs.HasKey(levelName))
            {
                string json = PlayerPrefs.GetString(levelName);
                return JsonUtility.FromJson<LevelProgress>(json);
            }
            return new LevelProgress();
        }
        
        public static void SavePlayerSettings(PlayerSettings settings)
        {
            string json = JsonUtility.ToJson(settings);
            PlayerPrefs.SetString("PlayerSettings", json);
            PlayerPrefs.Save();
        }

        public static PlayerSettings LoadPlayerSettings()
        {
            if (PlayerPrefs.HasKey("PlayerSettings"))
            {
                string json = PlayerPrefs.GetString("PlayerSettings");
                return JsonUtility.FromJson<PlayerSettings>(json);
            }
            return new PlayerSettings();
        }
    }
}