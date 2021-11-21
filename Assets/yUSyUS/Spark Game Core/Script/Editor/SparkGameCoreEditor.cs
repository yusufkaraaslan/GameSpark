using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SparkGameCore
{
    [CustomEditor(typeof(SparkGameCoreCenter))]
    public class SparkGameCoreEditor : Editor
    {
        int MainToolbarInt = 0;
        string[] toolbarStrings = { "Systems", "integration", "Settings" };

        int systemToolbarInd = 0;
        string systemToolbarString;

        SparkGameCoreCenter myTarget;
        SerializedObject soTarget;

        //  System Settings
        SerializedProperty sceneTemplate; 

        float elementSpace = 5;
        float sectionSpace = 20;

        private void OnEnable()
        {
            myTarget = (SparkGameCoreCenter)target;
            soTarget = new SerializedObject(target);

            sceneTemplate = soTarget.FindProperty("sceneTemplate");
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

                    DrawSystemsTap();

                    break;

                case 1:

                    DrawIntegrationTap();

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
            if (!myTarget.CurrScene.SoundManegerSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddApolloSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveApolloSystem(); }
            }

            //  Light
            GUILayout.Label("Light Sys");
            if (!myTarget.CurrScene.LightSystem)
            {
                if (GUILayout.Button("Add")) { myTarget.AddLightSystem(); }
            }
            else
            {
                if (GUILayout.Button("Remove")) { myTarget.RemoveLightSystem(); }
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

            if (myTarget.CurrScene.SoundManegerSystem)
            {
                systemTabs.Add("Sound");
            }

            if (myTarget.CurrScene.LightSystem)
            {
                systemTabs.Add("Light");
            }

            GUILayout.Space(sectionSpace);
            systemToolbarInd = GUILayout.Toolbar(systemToolbarInd, systemTabs.ToArray());
            if (systemTabs.Count == 0)
            {
                systemToolbarString = "";
            }
            else
            {
                systemToolbarString = systemTabs[systemToolbarInd];
            }
            GUILayout.Space(elementSpace);

            switch (systemToolbarString)
            {
                case "Pool":

                    myTarget.poolSetting.DrawTap();

                    break;

                case "UI":

                    myTarget.UISetting.DrawTap();

                    break;

                case "Camera":

                    myTarget.cameraSetting.DrawTap();

                    break;

                case "Visual Event":

                    myTarget.visualEventSetting.DrawTap();

                    break;

                case "Sound":

                    myTarget.SoundSetting.DrawTap();

                    break;

                case "Light":

                    myTarget.lightSetting.DrawTap();

                    break;
            }
        }

        public void DrawYatanaSettings()
        {
            GUILayout.Space(sectionSpace);
            GUILayout.Label("Coming Soon :) ");

            GUILayout.Space(sectionSpace);
            GUILayout.Label("Made By yUSyUS");
        }
        
    }
}