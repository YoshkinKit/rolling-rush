using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnFinish = new();

    public static void SendOnFinish()
    {
        OnFinish.Invoke();
    }
}
