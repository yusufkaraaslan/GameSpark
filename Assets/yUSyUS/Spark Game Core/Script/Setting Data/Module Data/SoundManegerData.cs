using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class SoundManegerData : DataTemplate
{
    public bool musicOn, soundOn;
    [Range(0.0f, 1.0f)] public float musicVolume, soundVolume;

    public GameAudioSource[] audioSources;
    public GameAudio[] clips;

    public override void DrawTap()
    {

#if UNITY_EDITOR
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

        SerializedProperty AudioSources = soTarget.FindProperty("audioSources");
        EditorGUILayout.PropertyField(AudioSources);
        GUILayout.Space(elementSpace);

        SerializedProperty Clips = soTarget.FindProperty("clips");
        EditorGUILayout.PropertyField(Clips);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
#endif
    }
}
