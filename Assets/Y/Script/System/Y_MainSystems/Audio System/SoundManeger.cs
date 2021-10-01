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

        static List<GameAudio> gameAudios;
        static SoundManeger manager;
        
        public AudioSource musicApollo;
        public AudioSource soundApollo;

        //
        static bool musicOn, soundOn;
        static float musicVolume, soundVolume;
        //

        public ApolloSettingData apolloSetting;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsOn", IsOn, typeof(bool));
            info.AddValue("gameAudios", gameAudios, typeof(List<GameAudio>));
            info.AddValue("manager", manager, typeof(SoundManeger));

            info.AddValue("musicOn", musicOn, typeof(bool));
            info.AddValue("soundOn", soundOn, typeof(bool));

            info.AddValue("musicVolume", musicVolume, typeof(float));
            info.AddValue("soundVolume", soundVolume, typeof(float));
        }

        public SoundManeger(SerializationInfo info, StreamingContext context)
        {
            IsOn = (bool)info.GetValue("IsOn", typeof(bool));
            gameAudios = (List<GameAudio>)info.GetValue("gameAudios", typeof(List<GameAudio>));
            manager = (SoundManeger)info.GetValue("manager", typeof(SoundManeger));

            musicOn = (bool)info.GetValue("musicOn", typeof(bool));
            soundOn = (bool)info.GetValue("soundOn", typeof(bool));

            musicVolume = (float)info.GetValue("musicVolume", typeof(float));
            soundVolume = (float)info.GetValue("soundVolume", typeof(float));
        }

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

            musicApollo = apolloSetting.musicApollo;
            soundApollo = apolloSetting.soundApollo;

            if (musicApollo == null)
            {
                Debug.LogError("Music audio source is null");
            }

            if (soundApollo == null)
            {
                Debug.LogError("Sound audio source is null");
            }

            foreach (GameAudio x in apolloSetting.audios)
            {
                gameAudios.Add(x);
            }

            musicOn = PlayerPrefs.GetInt("musicOn") == 1;
            soundOn = PlayerPrefs.GetInt("soundOn") == 1;

            musicVolume = PlayerPrefs.GetFloat("musicVolume");
            soundVolume = PlayerPrefs.GetFloat("soundVolume");

        }

        public void PlayMusic(string musicName)
        {
            if (musicOn)
            {
                foreach (GameAudio x in gameAudios)
                {
                    if (x.audioName == musicName)
                    {
                        musicApollo.clip = x.clip;
                        musicApollo.loop = true;
                        musicApollo.volume = musicVolume;
                        musicApollo.Play();
                    }
                }
            }
        }

        public void StopMusic()
        {
            musicApollo.Stop();
        }

        public void PlaySound(string soundName)
        {
            if (soundOn)
            {
                foreach (GameAudio x in gameAudios)
                {
                    if (x.audioName == soundName)
                    {
                        soundApollo.clip = x.clip;
                        soundApollo.volume = soundVolume;
                        soundApollo.Play();
                    }
                }
            }
        }

        public void MusicOn()
        {
            musicOn = true;
            PlayerPrefs.SetInt("musicOn", 1);
            musicApollo.Play();
        }

        public void MusicOff()
        {
            musicOn = false;
            PlayerPrefs.SetInt("musicOn", 0);
            musicApollo.Stop();
        }

        public void SoundOn()
        {
            PlayerPrefs.SetInt("soundOn", 1);
            soundOn = true;
        }

        public void SoundOff()
        {
            PlayerPrefs.SetInt("soundOn", 0);
            soundOn = false;
        }

        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
            PlayerPrefs.SetFloat("musicVolume", volume);
            musicApollo.volume = volume;
        }

        public void SetSoundValume(float volume)
        {
            soundVolume = volume;
            PlayerPrefs.SetFloat("soundVolume", volume);
            soundApollo.volume = volume;
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
