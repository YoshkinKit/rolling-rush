using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private CoinManager coinManager;
    [SerializeField] private float timeToGetCoins;
    public int StarsCount { get; private set; }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finish Game!");
            GlobalEventManager.SendOnFinish();
        }
    }

    private void CalculateStars()
    {
        StarsCount++;
        if (coinManager.Coins.Count == coinManager.CoinCount)
        {
            StarsCount++;
        }
        if (timer.LevelTime < timeToGetCoins)
        {
            StarsCount++;
        }
    }
}
