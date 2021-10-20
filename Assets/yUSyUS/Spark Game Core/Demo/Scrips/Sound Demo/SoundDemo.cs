using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Needed namespace
using SparkGameCore.MainSystems;

public class SoundDemo : DemoSceneTemplate
{
    // Maneger Instance
    SoundManeger soundManeger;
    UIManeger ui;

    [SerializeField] Slider musicSlider, soundSlider, noiseSlider;
    [SerializeField] GameObject sceneRoot;

    private void Start()
    {
        //  Get Maneger Instance
        soundManeger = SoundManeger.GetInstance();
        ui = UIManeger.GetInstance();
    }

    public override void StartDemo()
    {
        ui.OpenUI("SoundDemo");
        sceneRoot.SetActive(true);
    }

    public override void EndDemo()
    {
        ui.CloseUI("SoundDemo");

        soundManeger.StopMusic();
        soundManeger.StopSound();
        sceneRoot.SetActive(false);
    }

    public void PlayMusic(string musicName)
    {
        soundManeger.PlayMusic("Main Music", musicName);
    }

    public void PlayNoise(string musicName)
    {
        soundManeger.PlayMusic("Noise", musicName);
    }

    public void PlaySound(string soundName)
    {
        soundManeger.PlaySound("Sound FX 1", soundName);
    }

    public void StopMusic()
    {
        soundManeger.StopSource("Main Music");
    }

    public void StopNoise()
    {
        soundManeger.StopSource("Noise");
    }

    public void StopSound()
    {
        soundManeger.StopSource("Sound FX 1");
    }

    public void SetMusicVolume(float value)
    {
        soundManeger.SetMusicVolume(value);
    }

    public void MusicOn()
    {
        soundManeger.MusicOn();
    }

    public void MusicOff()
    {
        soundManeger.MusicOff();
    }

    public void SoundOn()
    {
        soundManeger.SoundOn();
    }

    public void SoundOff()
    {
        soundManeger.SoundOff();
    }

    public void SetMusicVolume()
    {
        soundManeger.SetMusicVolume(musicSlider.value);
    }

    public void SetSoundVolume()
    {
        soundManeger.SetSoundValume(soundSlider.value);
    }

    public void SetNoiseVolume()
    {
        soundManeger.SetSourceVolume("Noise", noiseSlider.value);
    }

}
