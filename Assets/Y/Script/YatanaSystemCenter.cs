using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainSystems;
using Yatana.MainSystems;
using UnityEditor;

namespace Yatana
{
    public class YatanaSystemCenter : MonoBehaviour
    {
        public SceneSetupProfile sceneTemplate;
        public SceneSetupProfile CurrScene;

        //  System profiles
        public PoolSystem pool;
        public PoolSettingData poolSetting;
        GameObject poolWaitPose;

        public UIManeger ui;
        public UISettingData UISetting;

        public CamSystem cam;
        public CameraSettingData cameraSetting;

        public VisualEventController visualEvent;
        public VisualEventSettingData visualEventSetting;
        GameObject visualEventObj;

        public SoundManeger apollo = SoundManeger.GetInstance();
        public ApolloSettingData apolloSetting = new ApolloSettingData();

        public YatanaSettingData yatanaSetting;

        //  Yatana Setting
        public bool isYatanaSettingChanged = false;

        public void ApplySceneTemplate()
        {
            if (sceneTemplate.PoolSystem)
            {
                AddPoolSystem();
            }
            else
            {
                RemovePoolSystem();
            }

            if (sceneTemplate.UISystem)
            {
                AddUISystem();
            }
            else
            {
                RemoveUISystem();
            }

            if (sceneTemplate.CameraSystem)
            {
                AddCameraSystem();
            }
            else
            {
                RemoveCameraSystem();
            }

            if (sceneTemplate.VisualEventSystem)
            {
                AddVisualEventSystem();
            }
            else
            {
                RemoveVisualEventSystem();
            }

            if (sceneTemplate.ApolloSystem)
            {
                AddApolloSystem();
            }
            else
            {
                RemoveApolloSystem();
            }
        }

        public void ClearTemplate()
        {
            sceneTemplate.PoolSystem = false;
            sceneTemplate.UISystem = false;
            sceneTemplate.CameraSystem = false;
            sceneTemplate.VisualEventSystem = false;
            sceneTemplate.ApolloSystem = false;
        }

        public void ClearScene()
        {
            RemovePoolSystem();
            RemoveUISystem();
            RemoveCameraSystem();
            RemoveVisualEventSystem();
            RemoveApolloSystem();
        }

        //  Integration System

        public void AddPoolSystem()
        {
            if (!CurrScene.PoolSystem)
            {
                CurrScene.PoolSystem = true;
                poolWaitPose = new GameObject("Pool Wait Pose");
                poolWaitPose.transform.SetParent(transform);
                poolWaitPose.transform.tag = "PoolWaiting";
            }
        }

        public void AddUISystem()
        {
            if (!CurrScene.UISystem)
            {
                CurrScene.UISystem = true;
            }
        }

        public void AddCameraSystem()
        {
            if (!CurrScene.CameraSystem)
            {
                CurrScene.CameraSystem = true;
            }
        }

        public void AddVisualEventSystem()
        {
            if (!CurrScene.VisualEventSystem)
            {
                CurrScene.VisualEventSystem = true;
                visualEventObj = new GameObject("Visual Event");
                visualEventObj.transform.SetParent(transform);
                visualEventObj.AddComponent<VisualEventController>();
            }
        }

        public void AddApolloSystem()
        {
            if (!CurrScene.ApolloSystem)
            {
                CurrScene.ApolloSystem = true;
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
            if (CurrScene.ApolloSystem)
            {
                CurrScene.ApolloSystem = false;
            }
        }

        //  Editor Functions

        public void EditorUpdate()
        {
            Debug.Log("ToDo : EditorUpdate");
        }

        public void YatanaSettingChanged()
        {
            isYatanaSettingChanged = true;
        }

        public void ApplyYatanaSettings()
        {
            /*
            isYatanaSettingChanged = false;

            for (int i = 0; i < transform.childCount; i++)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);
                };
            }

            modules = new List<YatanaModule>();

            foreach (string mName in yatanaSetting.modules)
            {
                Type typ = Type.GetType(mName);

                if (typ == null)
                {
                    throw new Exception("Type not Found");
                }

                YatanaModule tmp = null;

                try
                {
                    tmp = (YatanaModule)typ.GetMethod("GetInstance").Invoke(null, null);
                }
                catch(System.Exception )
                {
                    try
                    {
                        GameObject tmpObj = new GameObject(mName);
                        tmpObj.transform.SetParent(transform);

                        tmpObj.AddComponent(typ);

                        tmp = tmpObj.GetComponent<YatanaModule>().GetModule();
                    }
                    catch (Exception)
                    {
                        throw new Exception("Module Return null (1) : " + mName);
                        throw;
                    }
                }
                

                if (tmp == null)
                {
                    throw new Exception("Module Return null (2) : " + mName);
                }

                modules.Add(tmp);
            }

            //CurrScene = new SceneSetupProfile();
            //CurrScene.UpdateSystems(yatanaSetting.modules);
            //sceneTemplate.UpdateSystems(yatanaSetting.modules);
            */
        }

        //  Game Functions

        //  Workflow

        void InitYatana()
        {
            if (CurrScene.PoolSystem)
            {
                pool = PoolSystem.GetInstance();
                pool.poolSetting = poolSetting;
                pool.initilaze();
            }

            if (CurrScene.UISystem)
            {
                ui = UIManeger.GetInstance();
                ui.UISetting = UISetting;
                ui.initilaze();
            }

            if (CurrScene.CameraSystem)
            {
                cam = CamSystem.GetInstance();
                cam.cameraSetting = cameraSetting;
                cam.initilaze();
            }

            if (CurrScene.VisualEventSystem)
            {
                visualEvent = VisualEventController.Instance();
                visualEvent.visualEventSetting = visualEventSetting;
                visualEvent.initilaze();
            }

            if (CurrScene.ApolloSystem)
            {
                apollo = SoundManeger.GetInstance();
                apollo.apolloSetting = apolloSetting;
                apollo.initilaze();
            }

        }

        private void Awake()
        {
            InitYatana();
        }

        private void Start()
        {

        }

    }

}
