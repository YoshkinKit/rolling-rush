using RollingRush.Ads;
using UnityEngine;

namespace RollingRush.Core
{
    public class AudioEventsManager : MonoBehaviour
    {
        [SerializeField] private AudioSource backgroundMusicSource;
        [SerializeField] private AudioClip coinPickupSound;
        [SerializeField] private AudioClip finishSound;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AdsManager adsManager;
        
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
            GlobalEventManager.OnFinish.AddListener(PlayFinishSoundSubscription);
            GlobalEventManager.OnDeath.AddListener(PlayGameOverSoundSubscription);
        }

        private void OnDestroy()
        {
            GlobalEventManager.OnFinish.RemoveListener(PlayFinishSoundSubscription);
            GlobalEventManager.OnDeath.RemoveListener(PlayGameOverSoundSubscription);
        }

        private void PlayFinishSoundSubscription()
        {
            PlaySoundAfterAd(finishSound);
        }
        
        private void PlayGameOverSoundSubscription()
        {
            PlaySoundAfterAd(gameOverSound);
        }

        private void PlaySoundAfterAd(AudioClip clip)
        {
            backgroundMusicSource.enabled = false;
            if (adsManager.CanShowAd && adsManager.AdLoaded)
            {
                adsManager.ShowInterstitialAd(() => _source.PlayOneShot(clip));
            }
            else
            {
                _source.PlayOneShot(clip);
            }
            LevelLoadingManager.Instance.AttemptsCount++;
        }
    }
}