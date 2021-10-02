using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana.MainSystems
{
    [System.Serializable]
    public class SoundManeger : YatanaModule
    {
        static bool IsOn = false;
        static SoundManeger manager;

        List<GameAudio> gameAudios;
        List<GameAudioSource> audioSources;

        public ApolloSettingData apolloSetting;

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

            foreach (GameAudio x in apolloSetting.audios)
            {
                gameAudios.Add(x);
            }

            foreach (GameAudioSource source in apolloSetting.audioSources)
            {
                audioSources.Add(source);

                if (source.sourceType == AudioSourceType.Music)
                {
                    source.audioSource.volume = apolloSetting.musicVolume;
                }
                else
                {
                    source.audioSource.volume = apolloSetting.soundVolume;
                }
            }
        }

        public void PlayMusic(string sourceName, string musicName)
        {
            if (apolloSetting.musicOn)
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
                source.audioSource.volume = apolloSetting.musicVolume;
                source.audioSource.Play();
            }
        }

        public void StopMusic(string sourceName)
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

        public void PlaySound(string sourceName, string soundName)
        {
            if (apolloSetting.soundOn)
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
                source.audioSource.volume = apolloSetting.soundVolume;
                source.audioSource.Play();
            }
        }

        public void MusicOn()
        {
            apolloSetting.musicOn = true;
        }

        public void MusicOff()
        {
            apolloSetting.musicOn = false;
        }

        public void SoundOn()
        {
            apolloSetting.soundOn = true;
        }

        public void SoundOff()
        {
            apolloSetting.soundOn = false;
        }

        public void SetMusicVolume(float volume)
        {
            apolloSetting.musicVolume = volume;

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
            apolloSetting.soundVolume = volume;

            foreach (GameAudioSource x in audioSources)
            {
                if (x.sourceType == AudioSourceType.VfxSound)
                {
                    x.audioSource.volume = volume;
                }
            }
        }

        public YatanaModule GetModule()
        {
            throw new System.NotImplementedException();
        }

        public void InstanceInit()
        {
            throw new System.NotImplementedException();
        }

        public string GetModuleName()
        {
            return "Apollo";
        }

        public void Initilaze(YatanaSystemCenter yatanaControlCenter)
        {
            throw new System.NotImplementedException();
        }

        public void SystemOn()
        {
            IsOn = true;
        }

        public void SystemOff()
        {
            IsOn = false;
        }

        public void UpdateSystem()
        {
            throw new System.NotImplementedException();
        }

        public void AddSystem()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSystem()
        {
            throw new System.NotImplementedException();
        }

        public bool IsSystemOn()
        {
            return IsOn;
        }
    }
}
