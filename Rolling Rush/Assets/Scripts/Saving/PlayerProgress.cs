using System;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class PlayerProgress
    {
        public int highestLevelCompleted = 1;
        public int coinsCount;
        public int starsCount;
        public string skinName = "DefaultPlayerSkin";
    }
}
