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
        SerializedProperty sceneTemplate; 
        SerializedProperty CurrScene; 

        SerializedProperty PoolSetting;
        //SerializedProperty PoolObjects;

        SerializedProperty UISetting;
        //SerializedProperty UISetus;

        SerializedProperty CameraSetting;
        //SerializedProperty Cameras;

        SerializedProperty VisualEventSetting;
        //SerializedProperty VisualEventTemplates;

        SerializedProperty ApolloSetting;
        //SerializedProperty Audios;

        SerializedProperty YatanaSetting;

        float elementSpace = 5;
        float sectionSpace = 20;

        private void OnEnable()
        {
            myTarget = (YatanaSystemCenter)target;
            soTarget = new SerializedObject(target);

            sceneTemplate = soTarget.FindProperty("sceneTemplate"); 
            CurrScene = soTarget.FindProperty("CurrScene"); 

            PoolSetting = soTarget.FindProperty("poolSetting");
            //PoolObjects = (new SerializedObject(myTarget.poolSetting)).FindProperty("poolObjects");

            UISetting = soTarget.FindProperty("UISetting");
            //UISetus = (new SerializedObject(myTarget.UISetting)).FindProperty("setups");

            CameraSetting = soTarget.FindProperty("cameraSetting");
            //CameraSetting = (new SerializedObject(myTarget.cameraSetting)).FindProperty("cams");

            VisualEventSetting = soTarget.FindProperty("visualEventSetting");
            //VisualEventTemplates = (new SerializedObject(myTarget.visualEventSetting)).FindProperty("visualEventTemplates");

            ApolloSetting = soTarget.FindProperty("apolloSetting");
            //Audios = (new SerializedObject(myTarget.apolloSetting)).FindProperty("audios");

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

            //  Pool
            GUILayout.Label("Pool Sys");
            if (!myTarget.CurrScene.PoolSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddPoolSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemovePoolSystem(); }
            }

            //  UI
            GUILayout.Label("UI Sys");
            if (!myTarget.CurrScene.UISystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddUISystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveUISystem(); }
            }

            //  Cam
            GUILayout.Label("Camera Sys");
            if (!myTarget.CurrScene.CameraSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddCameraSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveCameraSystem(); }
            }

            //  Visual Event
            GUILayout.Label("Visual Event Sys");
            if (!myTarget.CurrScene.VisualEventSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddVisualEventSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveVisualEventSystem(); }
            }

            //  Apollo
            GUILayout.Label("Sound Sys");
            if (!myTarget.CurrScene.ApolloSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddApolloSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveApolloSystem(); }
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

                    //EditorGUILayout.PropertyField(PoolObjects);

                    break;

                case "UI":

                    EditorGUILayout.PropertyField(UISetting);
                    GUILayout.Space(sectionSpace);

                    break;

                case "Camera":

                    EditorGUILayout.PropertyField(CameraSetting);
                    GUILayout.Space(sectionSpace);

                    break;

                case "Visual Event":

                    EditorGUILayout.PropertyField(VisualEventSetting);
                    GUILayout.Space(elementSpace);

                    //EditorGUILayout.PropertyField(VisualEventTemplates);

                    GUILayout.Space(sectionSpace);

                    break;

                case "Apollo":

                    EditorGUILayout.PropertyField(ApolloSetting);
                    GUILayout.Space(elementSpace);

                    //EditorGUILayout.PropertyField(Audios);

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