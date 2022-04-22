using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Prefabs
{
    /// <summary>
    /// Instantiated in STARTSCREEN Scene. Controls the background audio.
    /// </summary>
    public class BackgroundAudioPrefab : MonoBehaviour
    {
        private AudioSource audioSource;
        private void Awake()
        {
            // Allow prefab to stay present throughout all scenes
            DontDestroyOnLoad(transform.gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio()
        {
            if (audioSource.isPlaying) return;
            audioSource.Play();
        }

        public void StopAudio()
        {
            audioSource.Stop();
        }
    }
}