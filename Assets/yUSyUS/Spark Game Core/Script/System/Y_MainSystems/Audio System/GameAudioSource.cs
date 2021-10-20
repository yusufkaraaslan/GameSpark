using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore.MainSystems
{
    public class GameAudioSource : MonoBehaviour
    {
        public string SourceName;
        public AudioSourceType sourceType;
        [HideInInspector] public AudioSource audioSource;

        public void Init()
        {
            audioSource = GetComponent<AudioSource>();
        }

    }

    public enum AudioSourceType
    {
        Music, VfxSound
    }

}
