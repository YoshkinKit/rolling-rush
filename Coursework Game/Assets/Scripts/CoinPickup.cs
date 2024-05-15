using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int _coinCount;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin") && gameObject.CompareTag("Player"))
        {
            _coinCount++;
            Destroy(other.gameObject);
        }
        
        Debug.Log(_coinCount);
    }
}
