using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore.MainSystems;

namespace SparkGameCore
{
    [System.Serializable]
    public class CameraSystem : SparkGameCoreModule
    {
        List<GameCam> cams;
        private static CameraSystem maneger;

        public CameraSettingData cameraSetting;

        public static CameraSystem GetInstance()
        {
            if (maneger == null)
            {
                maneger = new CameraSystem();
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

        private CameraSystem()
        {

        }

    }
}