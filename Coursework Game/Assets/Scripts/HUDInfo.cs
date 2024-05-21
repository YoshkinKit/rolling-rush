using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI coinsLeftText;
    [SerializeField] private List<GameObject> coins;
    private float _levelTime;

    private void Awake()
    {
        GlobalEventManager.OnCoinPickup.AddListener(() =>
        {
            coins.RemoveAt(0);
            coinsLeftText.text = $"Coins left: {coins.Count}";
        });
    }

    private void Start()
    {
        timerText.text = "00:00";
        coinsLeftText.text = $"Coins left: {coins.Count}";
    }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        _levelTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(_levelTime / 60);
        int seconds = Mathf.FloorToInt(_levelTime % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}
