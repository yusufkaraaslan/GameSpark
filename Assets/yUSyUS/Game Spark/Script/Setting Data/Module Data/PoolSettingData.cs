using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using GameSpark;

namespace GameSpark
{
    [System.Serializable]
    public class PoolSettingData : DataTemplate
    {
        public bool IsOn = false;

        public bool LockSystem;
        public bool CloseObjectOnDespawn = true;

        public int PoolInitilazeSize = 10;
        public int PoolMaxSize = 500;

        public PoolObject[] poolObjects;

        public override void DrawTap()
        {
#if UNITY_EDITOR
            SerializedObject soTarget = new SerializedObject(this);
            GUILayout.Space(sectionSpace);

            EditorGUI.BeginChangeCheck();

            SerializedProperty closeOnDespawn = soTarget.FindProperty("CloseObjectOnDespawn");
            EditorGUILayout.PropertyField(closeOnDespawn);
            GUILayout.Space(elementSpace);

            SerializedProperty poolInitilazeSize = soTarget.FindProperty("PoolInitilazeSize");
            EditorGUILayout.PropertyField(poolInitilazeSize);
            GUILayout.Space(elementSpace);

            SerializedProperty poolMaxSize = soTarget.FindProperty("PoolMaxSize");
            EditorGUILayout.PropertyField(poolMaxSize);
            GUILayout.Space(elementSpace);

            SerializedProperty poolObjs = soTarget.FindProperty("poolObjects");
            EditorGUILayout.PropertyField(poolObjs);
            GUILayout.Space(elementSpace);

            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
            }
#endif
        }
    }
}
