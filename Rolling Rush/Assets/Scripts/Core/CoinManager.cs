using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RollingRush.Core
{
    public class CoinManager : MonoBehaviour
    {
        public int CurrentCoinCount { get; private set; }
        public List<GameObject> RemainingCoins { get; private set; }

        private void Awake()
        {
            GlobalEventManager.OnCoinPickup.AddListener(coin =>
            {
                CurrentCoinCount++;
                Destroy(coin);
                RemainingCoins.Remove(coin);
            });
            RemainingCoins = GameObject.FindGameObjectsWithTag("Coin").ToList();
        }
    }
}
