using UnityEngine;

namespace CourseworkGame.Saving
{
    public static class SaveSystem
    {
        public static void SaveProgress(PlayerProgress progress)
        {
            string json = JsonUtility.ToJson(progress);
            Debug.Log(json);
            PlayerPrefs.SetString("PlayerProgress", json);
            PlayerPrefs.Save();
        }

        public static PlayerProgress LoadProgress()
        {
            if (PlayerPrefs.HasKey("PlayerProgress"))
            {
                string json = PlayerPrefs.GetString("PlayerProgress");
                return JsonUtility.FromJson<PlayerProgress>(json);
            }
            return new PlayerProgress();
        }
    }
}