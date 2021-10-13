using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SparkGameCore.MainSystems;

[System.Serializable]
public class CameraSettingData : DataTemplate
{
    public bool LockSystem;
    public bool SetOffCamOnRegister;

    public GameCam[] cams;

    public override void DrawTap()
    {
        SerializedObject soTarget = new SerializedObject(this);
        GUILayout.Space(sectionSpace);

        EditorGUI.BeginChangeCheck();

        SerializedProperty offCam = soTarget.FindProperty("SetOffCamOnRegister");
        EditorGUILayout.PropertyField(offCam);
        GUILayout.Space(elementSpace);

        SerializedProperty gameCams = soTarget.FindProperty("cams");
        EditorGUILayout.PropertyField(gameCams);
        GUILayout.Space(elementSpace);

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
    }
}
