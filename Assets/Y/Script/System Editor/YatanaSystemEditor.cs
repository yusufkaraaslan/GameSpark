using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MainSystems;

namespace Yatana
{
    [CustomEditor(typeof(YatanaSystemCenter))]
    public class YatanaSystemEditor : Editor
    {
        int MainToolbarInt = 0;
        string[] toolbarStrings = { "integration", "Systems", "Settings" };

        int systemToolbarInd = 0;
        string systemToolbarString;

        YatanaSystemCenter myTarget;
        SerializedObject soTarget;

        //  System Settings
        SerializedProperty CurrScene; 

        SerializedProperty PoolSetting;
        SerializedProperty PoolObjects;

        SerializedProperty UISetting;

        SerializedProperty CameraSetting;

        SerializedProperty PopupSetting;

        SerializedProperty VisualEventSetting;
        SerializedProperty VisualEventTemplates;

        SerializedProperty ApolloSetting;
        SerializedProperty Audios;

        SerializedProperty YatanaSetting;

        float elementSpace = 5;
        float sectionSpace = 20;

        private void OnEnable()
        {
            myTarget = (YatanaSystemCenter)target;
            soTarget = new SerializedObject(target);

            CurrScene = soTarget.FindProperty("CurrScene"); 

            PoolSetting = soTarget.FindProperty("poolSetting");
            PoolObjects = soTarget.FindProperty("poolObjects");

            UISetting = soTarget.FindProperty("UISetting");

            CameraSetting = soTarget.FindProperty("cameraSetting");

            PopupSetting = soTarget.FindProperty("popupSetting");

            VisualEventSetting = soTarget.FindProperty("visualEventSetting");
            VisualEventTemplates = soTarget.FindProperty("visualEventTemplates");

            ApolloSetting = soTarget.FindProperty("apolloSetting");
            Audios = soTarget.FindProperty("audios");

            YatanaSetting = soTarget.FindProperty("yatanaSetting");
        }

        public override void OnInspectorGUI()
        {
            soTarget.Update();
            EditorGUI.BeginChangeCheck();

            //  Toolbar
            MainToolbarInt = GUILayout.Toolbar(MainToolbarInt, toolbarStrings);

            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
                GUI.FocusControl(null);
            }

            EditorGUI.BeginChangeCheck();

            //  Tab Data
            switch (MainToolbarInt)
            {
                case 0:

                    DrawIntegrationTap();

                    break;

                case 1:

                    DrawSystemsTap();

                    break;

                case 2:

                    DrawYatanaSettings();

                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
            }

        }

        public void DrawIntegrationTap()
        {
            //  Scene template

            EditorGUILayout.PropertyField(sceneTemplate);

            GUILayout.Space(elementSpace);
            if (GUILayout.Button("Apply Template"))
            {
                myTarget.ApplySceneTemplate();
            }

            GUILayout.Space(sectionSpace);

            GUILayout.Label("Systems :");
            GUILayout.Space(elementSpace);

            EditorGUILayout.PropertyField(CurrScene); 

            /*
            foreach (YatanaModule m in myTarget.modules)
            {
                GUILayout.Label(m.GetModuleName());
                if (m.IsSystemOn())
                {
                    if (GUILayout.Button("Turn On")) { m.SystemOn(); }
                }
                else
                {
                    if (GUILayout.Button("Turn Off")) { m.SystemOff(); }
                }
            }
            */

            foreach (string m in myTarget.CurrScene.modules.Keys)
            {
                YatanaModule tmp = myTarget.GetModule(m);

                GUILayout.Label(m);
                if (!myTarget.CurrScene.modules[m])
                {
                    if (GUILayout.Button("Add")) { tmp.AddSystem(); }
                }
                else
                {
                    if (GUILayout.Button("Remove")) { tmp.RemoveSystem(); }
                }
            }

            GUILayout.Space(sectionSpace);

            if (GUILayout.Button("Clear Scene"))
            {
                myTarget.ClearScene();
            }

        }

        public void DrawSystemsTap()
        {
            List<string> systemTabs = new List<string>();

            foreach (YatanaModule m in myTarget.modules)
            {
                systemTabs.Add(m.GetModuleName());
            }

            if (myTarget.CurrScene.PoolSystem)
            {
                systemTabs.Add("Pool");
            }

            if (myTarget.CurrScene.UISystem)
            {
                systemTabs.Add("UI");
            }

            if (myTarget.CurrScene.CameraSystem)
            {
                systemTabs.Add("Camera");
            }

            if (myTarget.CurrScene.PopupSystem)
            {
                systemTabs.Add("Popup");
            }

            if (myTarget.CurrScene.VisualEventSystem)
            {
                systemTabs.Add("Visual Event");
            }

            if (myTarget.CurrScene.ApolloSystem)
            {
                systemTabs.Add("Apollo");
            }

            GUILayout.Space(sectionSpace);
            systemToolbarInd = GUILayout.Toolbar(systemToolbarInd, systemTabs.ToArray());
            systemToolbarString = systemTabs[systemToolbarInd];
            GUILayout.Space(elementSpace);

            EditorGUI.BeginChangeCheck();

            switch (systemToolbarString)
            {
                case "Pool":

                    EditorGUILayout.PropertyField(PoolSetting);
                    GUILayout.Space(sectionSpace);

                    EditorGUILayout.PropertyField(PoolObjects);

                    break;

                case "UI":

                    EditorGUILayout.PropertyField(UISetting);
                    GUILayout.Space(sectionSpace);

                    break;

                case "Camera":

                    EditorGUILayout.PropertyField(CameraSetting);
                    GUILayout.Space(sectionSpace);

                    break;

                case "Popup":

                    EditorGUILayout.PropertyField(PopupSetting);
                    GUILayout.Space(sectionSpace);

                    break;

                case "Visual Event":

                    EditorGUILayout.PropertyField(VisualEventSetting);
                    GUILayout.Space(elementSpace);

                    EditorGUILayout.PropertyField(VisualEventTemplates);

                    GUILayout.Space(sectionSpace);

                    break;

                case "Apollo":

                    EditorGUILayout.PropertyField(ApolloSetting);
                    GUILayout.Space(elementSpace);

                    EditorGUILayout.PropertyField(Audios);

                    GUILayout.Space(sectionSpace);

                    break;
            }

            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
            }
        }

        public void DrawYatanaSettings()
        {
            EditorGUI.BeginChangeCheck();

            if (myTarget.yatanaSetting == null)
            {
                myTarget.yatanaSetting = new YatanaSettingData();
            }

            myTarget.yatanaSetting.DrawTap();

            if (GUILayout.Button("Reset Modules")) { myTarget.yatanaSetting.ResetModules(); }
            GUILayout.Space(elementSpace);

            if (EditorGUI.EndChangeCheck())
            {
                soTarget.ApplyModifiedProperties();
                myTarget.YatanaSettingChanged();
            }

            if (myTarget.isYatanaSettingChanged)
            {
                if (GUILayout.Button("Apply Settings")){ myTarget.ApplyYatanaSettings();}
                GUILayout.Space(elementSpace);
            }

            GUILayout.Space(sectionSpace);
            GUILayout.Label("Made By yUSyUS");
        }
        
    }

}