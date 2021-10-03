using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class UISettingData : DataTemplate
{
    public bool LockSystem;
    public bool ClearAllUIOnStart;

    public UISetup[] setups;

    public override void DrawTap()
    {
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
    }
}
