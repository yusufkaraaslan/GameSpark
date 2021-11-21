using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class LightSettingData : DataTemplate
{
    public SceneLight[] lights;

    public override void DrawTap()
    {
#if UNITY_EDITOR
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty Lights = soTarget.FindProperty("lights");
        EditorGUILayout.PropertyField(Lights);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
#endif
    }
}