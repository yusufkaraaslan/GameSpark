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
        public PoolSettingData poolSetting;
        public PoolObj[] poolObjects;

        public UISettingData UISetting;

        public CameraSettingData cameraSetting;

        public PopupSettingData popupSetting;

        public VisualEventSettingData visualEventSetting;
        public VisualEventProfile[] visualEventTemplates;

        public ApolloSettingData apolloSetting;
        public GameAudio[] audios;

        public YatanaSettingData yatanaSetting;

        //  System objects
        [SerializeReference] public List<YatanaModule> modules;

        /*
        //  System objects
        [SerializeReference] public List<YatanaModule> modules;
        */

        //  Yatana Setting
        public bool isYatanaSettingChanged = false;

        public void ApplySceneTemplate()
        {
            if (sceneTemplate.PoolSystem)
            {
                
            }

            foreach (string item in sceneTemplate.modules.Keys)
            {
                CurrScene.modules[item] = sceneTemplate.modules[item];

                foreach (YatanaModule m in modules)
                {
                    if (m.GetModuleName() == item)
                    {
                        if (sceneTemplate.modules[item].IsSystemOn())
                        {
                            m.AddSystem();
                        }
                        else
                        {
                            m.RemoveSystem();
                        }

                        break;
                    }
                }

            }
        }

        public void ClearTemplate()
        {
            sceneTemplate.PoolSystem = false;
            sceneTemplate.UISystem = false;
            sceneTemplate.CameraSystem = false;
            sceneTemplate.PopupSystem = false;
            sceneTemplate.VisualEventSystem = false;
            sceneTemplate.ApolloSystem = false;
        }

        public void ClearScene()
        {
            foreach (YatanaModule m in modules)
            {
                m.RemoveSystem();
            }
        }

        //  Integration System

        public void AddPoolSystem()
        {
            if (!CurrScene.PoolSystem)
            {
                CurrScene.PoolSystem = true;
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

        public void AddPopupSystem()
        {
            if (!CurrScene.PopupSystem)
            {
                CurrScene.PopupSystem = true;
            }
        }

        public void AddVisualEventSystem()
        {
            if (!CurrScene.VisualEventSystem)
            {
                CurrScene.VisualEventSystem = true;
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

        public void RemovePopupSystem()
        {
            if (CurrScene.PopupSystem)
            {
                CurrScene.PopupSystem = false;
            }
        }

        public void RemoveVisualEventSystem()
        {
            if (CurrScene.VisualEventSystem)
            {
                CurrScene.VisualEventSystem = false;
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
            Debug.Log("helleoooooooo");
        }

        public void YatanaSettingChanged()
        {
            isYatanaSettingChanged = true;
        }

        public void ApplyYatanaSettings()
        {
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
        }

        //  Game Functions

        public YatanaModule GetModule(string mName)
        {
            for (int i = 0; i < modules.Count; i++)
            {
                if (modules[i].GetModuleName() == mName)
                {
                    return modules[i];
                }
            }

            return null;
        }

        //  Workflow

        private void Awake()
        {

        }

        private void Start()
        {

        }

    }

}
