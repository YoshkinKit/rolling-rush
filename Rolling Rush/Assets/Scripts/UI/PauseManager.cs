using UnityEngine;

namespace RollingRush.UI
{
    public class PauseManager : InGamePanelManager
    {
        private bool _isPaused;
    
        private void Start()
        {
            _isPaused = false;
            panel.SetActive(false);
        }

        public void TogglePause()
        {
            _isPaused = !_isPaused;
            panel.SetActive(_isPaused);
            Time.timeScale = _isPaused ? 0f : 1f;
        }

        public override void ResetLevel()
        {
            base.ResetLevel();
        }
    }
}
