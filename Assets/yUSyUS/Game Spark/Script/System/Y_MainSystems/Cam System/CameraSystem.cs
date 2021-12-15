using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;

namespace GameSpark
{
    [System.Serializable]
    public class CameraSystem : GameSparkModule
    {
        List<GameCam> cams;
        private static CameraSystem manager;

        public CameraSettingData cameraSetting;

        public static CameraSystem GetInstance()
        {
            if (manager == null)
            {
                manager = new CameraSystem();
            }

            return manager;
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

        public void SetCamOff(string camName)
        {
            SetCam(camName, new OffCam(), null);
        }

        public void SetCam(string camName, FixedCamLayout layout)
        {
            SetCam(camName, new FixedCam(), layout);
        }

        public void SetCam(string camName, BasicFollowCamLayout layout)
        {
            SetCam(camName, new BasicFollowCam(), layout);
        }

        //  For custom cam atribute
        public void SetCam(string camName, ICam atr, SparkCameraLayout layout)
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