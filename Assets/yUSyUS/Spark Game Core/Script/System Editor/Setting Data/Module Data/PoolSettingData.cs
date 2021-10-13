using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class PoolSettingData : DataTemplate
{
    public bool IsOn = false;

    public bool LockSystem;
    public bool CloseObjectOnDespawn;

    public PoolObj[] poolObjects;
    
    public override void DrawTap()
    {
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty closeOnDespawn = soTarget.FindProperty("CloseObjectOnDespawn");
        EditorGUILayout.PropertyField(closeOnDespawn);
        GUILayout.Space(elementSpace);

        SerializedProperty poolObjs = soTarget.FindProperty("poolObjects");
        EditorGUILayout.PropertyField(poolObjs);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
    }
}
