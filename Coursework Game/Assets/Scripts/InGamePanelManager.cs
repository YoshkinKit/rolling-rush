using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePanelManager : MonoBehaviour
{
    [SerializeField] protected GameObject panel;
    [SerializeField] protected TextMeshProUGUI timerText;
    
    public virtual void ResetLevel()
    {
        panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public virtual void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    protected void SetTimerText(string text)
    {
        timerText.text = text;
    }
}
