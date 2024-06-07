using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CourseworkGame.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip uiClickSound;
        
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayUIButtonClip()
        {
            _audioSource.PlayOneShot(uiClickSound);
        }
    }
}