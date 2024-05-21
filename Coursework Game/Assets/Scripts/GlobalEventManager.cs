using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnFinish = new();
    public static UnityEvent OnCoinPickup = new();

    public static void SendOnFinish()
    {
        OnFinish.Invoke();
    }
    
    public static void SendOnCoinPickup()
    {
        OnCoinPickup.Invoke();
    }
}
