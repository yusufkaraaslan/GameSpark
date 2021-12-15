using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;

namespace GameSpark
{
    public class LightManeger : GameSparkModule
    {
        static LightManeger manager;
        //List<SceneLight> lights;

        public LightSettingData settingData;

        public static LightManeger GetInstance()
        {
            if (manager == null)
            {
                manager = new LightManeger();
            }

            return manager;
        }

        public void Init()
        {
            //this.lights = new List<SceneLight>();

            foreach (SceneLight light in settingData.lights)
            {
                light.Initilaze();
                //this.lights.Add(light);
            }

        }

        public SceneLight GetLight(string lightName)
        {
            for (int i = 0; i < settingData.lights.Length; i++)
            {
                if (settingData.lights[i].lightName == lightName)
                {
                    return settingData.lights[i];
                }
            }

            Debug.LogError("Light not found.");
            return null;
        }

        private LightManeger()
        {

        }
    }
}
