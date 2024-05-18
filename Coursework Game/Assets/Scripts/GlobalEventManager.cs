using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnFinish = new UnityEvent();

    public static void SendOnFinish()
    {
        OnFinish.Invoke();
    }
}
