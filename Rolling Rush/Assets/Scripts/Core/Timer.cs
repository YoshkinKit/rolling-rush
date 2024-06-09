using UnityEngine;

namespace RollingRush.Core
{
    public class Timer : MonoBehaviour
    {
        public float LevelTime { get; private set; }
        private bool _isUpdating = true;

        private void Start()
        {
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                _isUpdating = false;
            });
        }

        private void Update()
        {
            if (!_isUpdating) return;
            LevelTime += Time.deltaTime;
        }
    }
}
