using UnityEngine;

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
        SetTimerText();
        Time.timeScale = _isPaused ? 0f : 1f;
    }

    public override void ResetLevel()
    {
        Time.timeScale = 1f;
        base.ResetLevel();
    }
}
