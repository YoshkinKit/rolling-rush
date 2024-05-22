public class DeathPanelManager : InGamePanelManager
{
    private void Start()
    {
        GlobalEventManager.OnDeath.AddListener(() =>
        {
            panel.SetActive(true);
        });
    }
}
