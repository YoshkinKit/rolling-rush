using UnityEngine;
using UnityEngine.Events;

namespace RollingRush.Core
{
    public class GlobalEventManager : MonoBehaviour
    {
        public static UnityEvent OnFinish = new();
        public static UnityEvent<GameObject> OnCoinPickup = new();
        public static UnityEvent OnDeath = new();

        public static void SendOnFinish()
        {
            OnFinish.Invoke();
        }
    
        public static void SendOnCoinPickup(GameObject coin)
        {
            OnCoinPickup.Invoke(coin);
        }
    
        public static void SendOnDeath()
        {
            OnDeath.Invoke();
        }
    }
}
