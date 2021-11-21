using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class UISettingData : DataTemplate
{
    public bool LockSystem;
    public bool ClearAllUIOnStart;

    public UISetup[] setups;

    public override void DrawTap()
    {
#if UNITY_EDITOR
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty clearAll = soTarget.FindProperty("ClearAllUIOnStart");
        EditorGUILayout.PropertyField(clearAll);
        GUILayout.Space(elementSpace);

        SerializedProperty uiSetups = soTarget.FindProperty("setups");
        EditorGUILayout.PropertyField(uiSetups);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
#endif
    }
}
