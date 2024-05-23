using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CourseworkGame.Core
{
    public class CoinManager : MonoBehaviour
    {
        public int CoinCount { get; private set; }
        public List<GameObject> Coins { get; private set; }

        private void Awake()
        {
            GlobalEventManager.OnCoinPickup.AddListener(coin =>
            {
                CoinCount++;
                Destroy(coin);
                Coins.Remove(coin);
            });
            Coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
        }
    }
}
