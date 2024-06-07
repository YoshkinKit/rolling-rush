using System;
using CourseworkGame.Core;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class PlayerSettings
    {
        public Movement.MovementType movementType;
        public float masterVolume = 1f;
        public bool musicIsOn = true;
        public bool sfxIsOn = true;
    }
}