using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class ApolloSettingData : DataTemplate
{
    public bool musicOn, soundOn;
    [Range(0.0f, 1.0f)] public float musicVolume, soundVolume;

    public GameAudio[] audios;
    public GameAudioSource[] audioSources;

    public override void DrawTap()
    {
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty isMusicOn = soTarget.FindProperty("musicOn");
        EditorGUILayout.PropertyField(isMusicOn);
        GUILayout.Space(elementSpace);

        SerializedProperty isSoundOn = soTarget.FindProperty("soundOn");
        EditorGUILayout.PropertyField(isSoundOn);
        GUILayout.Space(elementSpace);

        SerializedProperty MusicVolume = soTarget.FindProperty("musicVolume");
        EditorGUILayout.PropertyField(MusicVolume);
        GUILayout.Space(elementSpace);

        SerializedProperty SoundVolume = soTarget.FindProperty("soundVolume");
        EditorGUILayout.PropertyField(SoundVolume);
        GUILayout.Space(elementSpace);

        SerializedProperty Audios = soTarget.FindProperty("audios");
        EditorGUILayout.PropertyField(Audios);
        GUILayout.Space(elementSpace);

        SerializedProperty AudioSources = soTarget.FindProperty("audioSources");
        EditorGUILayout.PropertyField(AudioSources);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
    }
}
