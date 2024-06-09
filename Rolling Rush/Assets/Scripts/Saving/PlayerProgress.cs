using System;

namespace RollingRush.Saving
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
