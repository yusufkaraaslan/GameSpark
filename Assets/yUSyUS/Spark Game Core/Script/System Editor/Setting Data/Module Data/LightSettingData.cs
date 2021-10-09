using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class LightSettingData : DataTemplate
{
    public SceneLight[] lights;

    public override void DrawTap()
    {
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
    }
}