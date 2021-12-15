using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;

namespace GameSpark
{
    [System.Serializable]
    public class UIManager : GameSparkModule
    {
        List<UISetup> uiSetups;
        static UIManager manager;

        public UISettingData UISetting;

        public static UIManager GetInstance()
        {
            if (manager == null)
            {
                manager = new UIManager();
            }

            return manager;
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

        private UIManager()
        {

        }
    }
}
