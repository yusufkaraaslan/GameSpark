using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yatana.MainSystems;

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

        SerializedProperty poolObjs = soTarget.FindProperty("poolObjects");

        EditorGUILayout.PropertyField(poolObjs);
        GUILayout.Space(sectionSpace);
    }
}
