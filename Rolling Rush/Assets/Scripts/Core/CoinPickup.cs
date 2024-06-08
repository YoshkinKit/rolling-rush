using UnityEngine;

namespace CourseworkGame.Core
{
    public class CoinPickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Coin"))
            {
                GlobalEventManager.SendOnCoinPickup(other.gameObject);
            }
        }
    }
}