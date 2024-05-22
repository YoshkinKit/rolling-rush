using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private List<GameObject> _coins;
    
    private int _coinCount;

    private void Awake()
    {
        GlobalEventManager.OnFinish.AddListener(() =>
        {
            Debug.Log($"Finished level with: {_coinCount} coins");
        });
        _coins = GameObject.FindGameObjectsWithTag("Coin").ToList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin") && CompareTag("Player"))
        {
            _coinCount++;
            Destroy(other.gameObject);
            _coins.Remove(other.gameObject);
            GlobalEventManager.SendOnCoinPickup();
        }
    }
}