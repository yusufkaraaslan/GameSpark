using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace SparkGameCore.MainSystems
{
    [System.Serializable]
    public class SoundManeger : YatanaModule
    {
        static SoundManeger manager;

        List<GameAudio> gameAudios;
        List<GameAudioSource> audioSources;

        public SoundManegerData SettingData;

        private SoundManeger()
        {

        }

        public static SoundManeger GetInstance()
        {
            if (manager == null)
            {
                manager = new SoundManeger();
            }

            return manager;
        }

        public void initilaze()
        {
            if (manager == null)
            {
                manager = new SoundManeger();
            }

            gameAudios = new List<GameAudio>();

            foreach (GameAudio x in SettingData.audios)
            {
                gameAudios.Add(x);
            }

            foreach (GameAudioSource source in SettingData.audioSources)
            {
                audioSources.Add(source);

                if (source.sourceType == AudioSourceType.Music)
                {
                    source.audioSource.volume = SettingData.musicVolume;
                }
                else
                {
                    source.audioSource.volume = SettingData.soundVolume;
                }
            }
        }

        public void PlayMusic(string sourceName, string musicName)
        {
            if (SettingData.musicOn)
            {
                GameAudioSource source = null;
                GameAudio audio = null;

                foreach (GameAudioSource x in audioSources)
                {
                    if (x.SourceName == sourceName)
                    {
                        source = x;
                        break;
                    }
                }

                foreach (GameAudio x in gameAudios)
                {
                    if (x.audioName == musicName)
                    {
                        audio = x;
                        break;
                    }
                }

                source.audioSource.clip = audio.clip;
                source.audioSource.loop = true;
                source.audioSource.volume = SettingData.musicVolume;
                source.audioSource.Play();
            }
        }

        public void PlaySound(string sourceName, string soundName)
        {
            if (SettingData.soundOn)
            {
                GameAudioSource source = null;
                GameAudio audio = null;

                foreach (GameAudioSource x in audioSources)
                {
                    if (x.SourceName == sourceName)
                    {
                        source = x;
                        break;
                    }
                }

                foreach (GameAudio x in gameAudios)
                {
                    if (x.audioName == soundName)
                    {
                        audio = x;
                        break;
                    }
                }

                source.audioSource.clip = audio.clip;
                source.audioSource.loop = false;
                source.audioSource.volume = SettingData.soundVolume;
                source.audioSource.Play();
            }
        }

        public void StopSource(string sourceName)
        {
            foreach (GameAudioSource x in audioSources)
            {
                if (x.SourceName == sourceName)
                {
                    x.audioSource.Stop();
                    break;
                }
            }
        }

        public void StopMusic()
        {
            foreach (GameAudioSource x in audioSources)
            {
                if (x.sourceType == AudioSourceType.Music)
                {
                    x.audioSource.Stop();
                }
            }
        }

        public void StopSound()
        {
            foreach (GameAudioSource x in audioSources)
            {
                if (x.sourceType == AudioSourceType.VfxSound)
                {
                    x.audioSource.Stop();
                }
            }
        }

        public void MusicOn()
        {
            SettingData.musicOn = true;
        }

        public void MusicOff()
        {
            SettingData.musicOn = false;
            StopMusic();
        }

        public void SoundOn()
        {
            SettingData.soundOn = true;
        }

        public void SoundOff()
        {
            SettingData.soundOn = false;
            StopSound();
        }

        public void SetMusicVolume(float volume)
        {
            SettingData.musicVolume = volume;

            foreach (GameAudioSource x in audioSources)
            {
                if (x.sourceType == AudioSourceType.Music)
                {
                    x.audioSource.volume = volume;
                }
            }
        }

        public void SetSoundValume(float volume)
        {
            SettingData.soundVolume = volume;

            foreach (GameAudioSource x in audioSources)
            {
                if (x.sourceType == AudioSourceType.VfxSound)
                {
                    x.audioSource.volume = volume;
                }
            }
        }

    }
}
