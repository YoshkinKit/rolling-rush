using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") && CompareTag("Player"))
        {
            GlobalEventManager.SendOnCoinPickup(other.gameObject);
        }
    }
}