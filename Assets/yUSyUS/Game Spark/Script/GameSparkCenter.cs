using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameSpark
{
    public class GameSparkCenter : MonoBehaviour
    {
        public SceneSetupProfile CurrScene;

        //  System profiles
        PoolSystem pool;
        public PoolSettingData poolSetting;
        [SerializeReference] GameObject poolWaitPose;

        UIManager ui;
        public UISettingData UISetting;

        CameraSystem cam;
        public CameraSettingData cameraSetting;

        VisualEventController visualEvent;
        public VisualEventSettingData visualEventSetting;
        [SerializeReference] GameObject visualEventObj;

        SoundManeger soundManeger;
        public SoundManegerData SoundSetting;

        LightManeger lightSys;
        public LightSettingData lightSetting;

        //  Yatana Setting
        //bool isYatanaSettingChanged = false;

        public void ClearScene()
        {
            RemovePoolSystem();
            RemoveUISystem();
            RemoveCameraSystem();
            RemoveVisualEventSystem();
            RemoveApolloSystem();
            RemoveLightSystem();
        }

        //  Integration System

        public void AddPoolSystem()
        {
            if (!CurrScene.PoolSystem)
            {
                CurrScene.PoolSystem = true;
                poolWaitPose = new GameObject("Pool Wait Pose");
                poolWaitPose.transform.SetParent(transform);
                CreateTag("PoolWaiting");
                poolWaitPose.transform.tag = "PoolWaiting";

                poolSetting = new PoolSettingData();
            }
        }

        public void AddUISystem()
        {
            if (!CurrScene.UISystem)
            {
                CurrScene.UISystem = true;

                UISetting = new UISettingData();
            }
        }

        public void AddCameraSystem()
        {
            if (!CurrScene.CameraSystem)
            {
                CurrScene.CameraSystem = true;

                cameraSetting = new CameraSettingData();
            }
        }

        public void AddVisualEventSystem()
        {
            if (!CurrScene.VisualEventSystem)
            {
                CurrScene.VisualEventSystem = true;

                visualEventObj = new GameObject("Visual Event Runner");
                visualEventObj.transform.SetParent(transform);
                visualEventObj.AddComponent<VisualEventRunner>();

                visualEventSetting = new VisualEventSettingData();
            }
        }

        public void AddApolloSystem()
        {
            if (!CurrScene.SoundManegerSystem)
            {
                CurrScene.SoundManegerSystem = true;

                SoundSetting = new SoundManegerData();
            }
        }

        public void AddLightSystem()
        {
            if (!CurrScene.LightSystem)
            {
                CurrScene.LightSystem = true;

                lightSetting = new LightSettingData();
            }
        }

        //----

        public void RemovePoolSystem()
        {
            if (CurrScene.PoolSystem)
            {
                CurrScene.PoolSystem = false;
                DestroyImmediate(poolWaitPose);
            }
        }

        public void RemoveUISystem()
        {
            if (CurrScene.UISystem)
            {
                CurrScene.UISystem = false;
            }
        }

        public void RemoveCameraSystem()
        {
            if (CurrScene.CameraSystem)
            {
                CurrScene.CameraSystem = false;
            }
        }

        public void RemoveVisualEventSystem()
        {
            if (CurrScene.VisualEventSystem)
            {
                CurrScene.VisualEventSystem = false;
                DestroyImmediate(visualEventObj);
            }
        }

        public void RemoveApolloSystem()
        {
            if (CurrScene.SoundManegerSystem)
            {
                CurrScene.SoundManegerSystem = false;
            }
        }

        public void RemoveLightSystem()
        {
            if (CurrScene.LightSystem)
            {
                CurrScene.LightSystem = false;
            }
        }

        //  Editor Functions

        public void EditorUpdate()
        {
            Debug.Log("ToDo : EditorUpdate");
        }

        public void YatanaSettingChanged()
        {
            //isYatanaSettingChanged = true;
        }

        public void ApplyYatanaSettings()
        {
            Debug.Log("ToDo : EditorUpdate");
        }

        //  Game Functions

        public static void CreateTag(string tag)
        {
#if UNITY_EDITOR
            var asset = AssetDatabase.LoadMainAssetAtPath("ProjectSettings/TagManager.asset");
            if (asset != null)
            { // sanity checking
                var so = new SerializedObject(asset);
                var tags = so.FindProperty("tags");

                var numTags = tags.arraySize;
                // do not create duplicates
                for (int i = 0; i < numTags; i++)
                {
                    var existingTag = tags.GetArrayElementAtIndex(i);
                    if (existingTag.stringValue == tag) return;
                }

                tags.InsertArrayElementAtIndex(numTags);
                tags.GetArrayElementAtIndex(numTags).stringValue = tag;
                so.ApplyModifiedProperties();
                so.Update();
            }
#endif
        }

        //  Workflow

        void InitGameSpark()
        {
            if (CurrScene.PoolSystem)
            {
                pool = PoolSystem.GetInstance();
                pool.poolSetting = poolSetting;
                pool.initilaze();
            }

            if (CurrScene.UISystem)
            {
                ui = UIManager.GetInstance();
                ui.UISetting = UISetting;
                ui.initilaze();
            }

            if (CurrScene.CameraSystem)
            {
                cam = CameraSystem.GetInstance();
                cam.cameraSetting = cameraSetting;
                cam.initilaze();
            }

            if (CurrScene.VisualEventSystem)
            {
                visualEvent = VisualEventController.GetInstance();
                visualEvent.visualEventSetting = visualEventSetting;
                visualEvent.initilaze();
            }

            if (CurrScene.SoundManegerSystem)
            {
                soundManeger = SoundManeger.GetInstance();
                soundManeger.SettingData = SoundSetting;
                soundManeger.initilaze();
            }

            if (CurrScene.LightSystem)
            {
                lightSys = LightManeger.GetInstance();
                lightSys.settingData = lightSetting;
                lightSys.Init();
            }

        }

        private void Awake()
        {
            InitGameSpark();
        }

    }

}
