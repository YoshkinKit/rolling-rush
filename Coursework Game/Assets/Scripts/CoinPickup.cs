using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int _coinCount;

    private void Awake()
    {
        GlobalEventManager.OnFinish.AddListener(() =>
        {
            Debug.Log($"Finished level with: {_coinCount} coins");
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") && CompareTag("Player"))
        {
            _coinCount++;
            Destroy(other.gameObject);
            GlobalEventManager.SendOnCoinPickup();
            Debug.Log(_coinCount);
        }
    }
}