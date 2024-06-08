using UnityEngine;

namespace CourseworkGame.Core
{
    public class AudioEventsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusicSource;
        [SerializeField] private AudioClip coinPickupSound;
        [SerializeField] private AudioClip finishSound;
        [SerializeField] private AudioClip gameOverSound;
        
        private AudioSource _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            SetAudioSubscriptions();
        }

        private void SetAudioSubscriptions()
        {
            GlobalEventManager.OnCoinPickup.AddListener(_ => _source.PlayOneShot(coinPickupSound));
            GlobalEventManager.OnFinish.AddListener(() =>
            {
                backgroundMusicSource.enabled = false;
                _source.PlayOneShot(finishSound);
            });
            GlobalEventManager.OnDeath.AddListener(() =>
            {
                backgroundMusicSource.enabled = false;
                _source.PlayOneShot(gameOverSound);
            });
        }
    }
}