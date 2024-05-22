using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePanelManager : MonoBehaviour
{
    [SerializeField] protected GameObject panel;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Timer timer;
    
    public virtual void ResetLevel()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    protected void SetTimerText()
    {
        int minutes = Mathf.FloorToInt(timer.LevelTime / 60);
        int seconds = Mathf.FloorToInt(timer.LevelTime % 60);

        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
