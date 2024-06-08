using UnityEngine;

namespace CourseworkGame.Core
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
