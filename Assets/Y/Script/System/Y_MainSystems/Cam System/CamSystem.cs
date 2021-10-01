using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable]
        public class CamSystem : YatanaModule
        {
            static bool IsOn;

            private static List<GameCam> cams;
            private static CamSystem camSystem;

            public CameraSettingData cameraSetting;

            public void initilaze()
            {
                if (camSystem == null)
                {
                    camSystem = new CamSystem();
                }
                cams = new List<GameCam>();

                for (int i = 0; i < cameraSetting.cams.Length; i++)
                {
                    cams.Add(cameraSetting.cams[i].GetComponent<GameCam>());
                    cams[i].SetICam(new OffCam(), null);
                }

            }

            public static CamSystem GetInstance()
            {
                if (camSystem == null)
                {
                    camSystem = new CamSystem();
                }

                return camSystem;
            }

            public void SetCam(string camName, ICam atr, Layout layout)
            {
                for (int i = 0; i < cams.Count; i++)
                {
                    if (cams[i].camName == camName)
                    {
                        cams[i].SetICam(atr, layout);
                        break;
                    }
                }
            }

            public GameCam GetCam(string camName)
            {
                foreach (GameCam x in cams)
                {
                    if (x.camName == camName)
                    {
                        return x;
                    }
                }

                return null;
            }

            public YatanaModule GetModule()
            {
                return GetInstance();
            }

            public string GetModuleName()
            {
                return "Camera Sys";
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

            private CamSystem()
            {

            }

        }
    }

}