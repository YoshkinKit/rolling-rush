using System;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class LevelProgress
    {
        public float recordTime = float.MaxValue;
        public bool gotStarForLevelCompletion;
        public bool gotStarForFastCompletion;
        public bool gotStarForCollectingCoins;
    }
}