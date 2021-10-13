using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace SparkGameCore
{
    namespace MainSystems
    {
        [System.Serializable]
        public class UIManeger : YatanaModule
        {
            List<UISetup> uiSetups;
            static UIManeger maneger;

            public UISettingData UISetting;

            public static UIManeger GetInstance()
            {
                if (maneger == null)
                {
                    maneger = new UIManeger();
                }

                return maneger;
            }

            public void initilaze()
            {
                uiSetups = new List<UISetup>();

                for (int i = 0; i < UISetting.setups.Length; i++)
                {
                    uiSetups.Add(UISetting.setups[i].GetComponent<UISetup>());
                    uiSetups[i].Initilaze();
                    uiSetups[i].Disable();
                }
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
                    uiSetups[i].CloseUI(true);
                }
            }

            private UIManeger()
            {

            }
        }
    }
}
