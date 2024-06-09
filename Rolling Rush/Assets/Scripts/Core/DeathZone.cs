using UnityEngine;

namespace RollingRush.Core
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GlobalEventManager.SendOnDeath();
            }
        }
    }
}
