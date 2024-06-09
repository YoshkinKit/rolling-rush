using System;
using GoogleMobileAds.Api;
using RollingRush.Core;
using UnityEngine;

namespace RollingRush.Ads
{
    public class AdsManager : MonoBehaviour
    {
        private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
        private InterstitialAd _interstitialAd;
        private Action _onAdClosedCallback;

        public bool CanShowAd => LevelLoadingManager.Instance.AttemptsCount % 3 == 0;
        public bool AdLoaded => _interstitialAd != null;
        
        public void Start()
        {
            MobileAds.Initialize(initStatus => { });
            if (CanShowAd)
                LoadInterstitialAd();
        }
        
        private void LoadInterstitialAd()
        {
            if (_interstitialAd != null)
            {
                _interstitialAd.Destroy();
                _interstitialAd = null;
            }

            Debug.Log("Loading the interstitial ad.");
            
            var adRequest = new AdRequest();
            
            InterstitialAd.Load(_adUnitId, adRequest, (ad, error) =>
                {
                    if (error != null || ad == null)
                    {
                        Debug.LogError($"interstitial ad failed to load an ad with error: {error}");
                        return;
                    }

                    Debug.Log($"Interstitial ad loaded with response: {ad.GetResponseInfo()}");

                    _interstitialAd = ad;
                    _interstitialAd.OnAdFullScreenContentClosed += HandleOnAdClosed;
                }
            );
        }

        private void HandleOnAdClosed()
        {
            _onAdClosedCallback?.Invoke();
        }

        public void ShowInterstitialAd(Action onAdClosedCallback)
        {
            _onAdClosedCallback = onAdClosedCallback;

            if (!CanShowAd) return;

            if (_interstitialAd != null && _interstitialAd.CanShowAd())
            {
                Debug.Log("Showing interstitial ad.");
                _interstitialAd.Show();
            }
            else
            {
                Debug.LogError("Interstitial ad is not ready yet.");
            }
        }
    }
}