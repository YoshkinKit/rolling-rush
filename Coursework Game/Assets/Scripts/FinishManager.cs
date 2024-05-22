using System;

public class FinishManager : InGamePanelManager
{
    private void Start()
    {
        panel.SetActive(false);
        
        GlobalEventManager.OnFinish.AddListener(() =>
        {
            panel.SetActive(true);
            SetTimerText();
        });
    }
}
