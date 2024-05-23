using System;
using System.Collections.Generic;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class LevelProgress
    {
        public List<int> collectedCoins = new();
    }
}