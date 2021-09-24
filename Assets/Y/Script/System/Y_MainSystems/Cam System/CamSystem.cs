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

            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("IsOn", IsOn, typeof(bool));
                info.AddValue("cams", cams, typeof(List<GameCam>));
                info.AddValue("camSystem", camSystem, typeof(CamSystem));
            }

            public CamSystem(SerializationInfo info, StreamingContext context)
            {
                IsOn = (bool)info.GetValue("IsOn", typeof(bool));
                cams = (List<GameCam>)info.GetValue("cams", typeof(List<GameCam>));
                camSystem = (CamSystem)info.GetValue("poolSystem", typeof(CamSystem));
            }

            public static void initilaze(GameObject[] samples)
            {
                if (camSystem == null)
                {
                    camSystem = new CamSystem();
                }
                cams = new List<GameCam>();

                for (int i = 0; i < samples.Length; i++)
                {
                    cams.Add(samples[i].GetComponent<GameCam>());
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

            public CamSystem()
            {

            }

        }
    }

}