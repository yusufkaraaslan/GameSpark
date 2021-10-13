using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore.MainSystems
{
    public class GameAudioSource : MonoBehaviour
    {
        public string SourceName;
        public AudioSourceType sourceType;
        public AudioSource audioSource;

    }

    public enum AudioSourceType
    {
        Music, VfxSound
    }

}
