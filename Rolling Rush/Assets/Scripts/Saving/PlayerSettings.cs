using System;
using RollingRush.Core;

namespace RollingRush.Saving
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