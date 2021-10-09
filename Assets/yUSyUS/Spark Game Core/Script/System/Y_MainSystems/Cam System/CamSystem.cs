using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

namespace Yatana.MainSystems
{
    [System.Serializable]
    public class CamSystem : YatanaModule
    {
        List<GameCam> cams;
        private static CamSystem maneger;

        public CameraSettingData cameraSetting;

        public static CamSystem GetInstance()
        {
            if (maneger == null)
            {
                maneger = new CamSystem();
            }

            return maneger;
        }

        public void initilaze()
        {
            cams = new List<GameCam>();

            for (int i = 0; i < cameraSetting.cams.Length; i++)
            {
                cams.Add(cameraSetting.cams[i].GetComponent<GameCam>());
                cams[i].SetICam(new OffCam(), null);
            }

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

        private CamSystem()
        {

        }

    }
}