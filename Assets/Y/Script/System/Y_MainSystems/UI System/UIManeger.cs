using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable]
        public class UIManeger : YatanaModule
        {
            static bool IsOn = false;
            static List<UISetup> uiSetups;
            static UIManeger maneger;

            public UISettingData UISetting;

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("IsOn", IsOn, typeof(bool));
                info.AddValue("uiSetups", uiSetups, typeof(List<UISetup>));
                info.AddValue("maneger", maneger, typeof(UIManeger));
            }

            public UIManeger(SerializationInfo info, StreamingContext context)
            {
                IsOn = (bool)info.GetValue("IsOn", typeof(bool));
                uiSetups = (List<UISetup>)info.GetValue("uiSetups", typeof(List<UISetup>));
                maneger = (UIManeger)info.GetValue("poolSystem", typeof(UIManeger));
            }

            public static void initilaze(GameObject[] objs)
            {
                if (maneger == null)
                {
                    maneger = new UIManeger();
                }

                uiSetups = new List<UISetup>();

                for (int i = 0; i < objs.Length; i++)
                {
                    uiSetups.Add(objs[i].GetComponent<UISetup>());
                }

                maneger.ClearScreen();
            }

            public static UIManeger GetInstance()
            {
                if (maneger == null)
                {
                    maneger = new UIManeger();
                }

                return maneger;
            }

            public void OpenUI(string setup)
            {
                for (int i = 0; i < uiSetups.Count; i++)
                {
                    if (string.Compare(uiSetups[i].UIName, setup) == 0)
                    {
                        uiSetups[i].OpenUI();
                        return;
                    }
                }

                Debug.LogError(setup + " cant find.");
            }

            public void OpenUIClean(string setup)
            {
                ClearScreen();
                OpenUI(setup);
            }

            public void CloseUI(string setup)
            {
                for (int i = 0; i < uiSetups.Count; i++)
                {
                    if (uiSetups[i].UIName == setup)
                    {
                        uiSetups[i].CloseUI();
                        return;
                    }
                }

                Debug.LogError(setup + " cant find.");
            }

            public void ClearScreen()
            {
                for (int i = 0; i < uiSetups.Count; i++)
                {
                    uiSetups[i].CloseUI();
                }
            }

            public string GetModuleName()
            {
                return "UI Sys";
            }

            public void Initilaze(YatanaSystemCenter yatanaControlCenter)
            {
                throw new System.NotImplementedException();
            }

            public void SystemOn()
            {
                IsOn = true;
            }

            public void SystemOff()
            {
                IsOn = false;
            }

            public void UpdateSystem()
            {
                throw new System.NotImplementedException();
            }

            public YatanaModule GetModule()
            {
                return GetInstance();
            }

            public void InstanceInit()
            {
                throw new System.NotImplementedException();
            }

            public void AddSystem()
            {
                throw new System.NotImplementedException();
            }

            public void RemoveSystem()
            {
                throw new System.NotImplementedException();
            }

            public bool IsSystemOn()
            {
                return IsOn;
            }

            public UIManeger()
            {

            }
        }
    }
}
