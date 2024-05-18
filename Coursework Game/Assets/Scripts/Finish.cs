using UnityEngine;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Finish Game!");
            GlobalEventManager.SendOnFinish();
        }
    }
}
