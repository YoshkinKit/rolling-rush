using System;
using CourseworkGame.Core;

namespace CourseworkGame.Saving
{
    [Serializable]
    public class PlayerSettings
    {
        public Movement.MovementType movementType;
        public float masterVolume;
        public float musicVolume;
        public float sfxVolume;
    }
}