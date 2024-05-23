using System;
using System.Collections.Generic;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class PlayerProgress
    {
        public int highestLevelCompleted;
        public Dictionary<string, LevelProgress> LevelProgresses = new();
    }
}
