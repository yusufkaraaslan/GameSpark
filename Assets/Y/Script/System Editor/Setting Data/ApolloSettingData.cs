using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class ApolloSettingData : DataTemplate
{
    public string[] SoundChannels = { "Music", "FX" };
    [Range(0.0f, 1.0f)] public float maxSound = 1, minSound = 0;

    public GameAudio[] audios;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
