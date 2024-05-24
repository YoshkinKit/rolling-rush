using System;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class LevelProgress
    {
        public float recordTime = float.MaxValue;
        public bool gotCoinForLevelCompletion;
        public bool gotCoinForFastCompletion;
        public bool gotCoinForCollectingCoins;
    }
}