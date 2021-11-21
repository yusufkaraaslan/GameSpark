using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class VisualEventSettingData : DataTemplate
{
    public bool LockSystem;
    public bool UseFixedUpdate;

    public VisualEventProfile[] visualEventTemplates;

    public override void DrawTap()
    {
#if UNITY_EDITOR
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty useFixed = soTarget.FindProperty("UseFixedUpdate");
        EditorGUILayout.PropertyField(useFixed);
        GUILayout.Space(elementSpace);

        SerializedProperty events = soTarget.FindProperty("visualEventTemplates");
        EditorGUILayout.PropertyField(events);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
#endif
    }
}
