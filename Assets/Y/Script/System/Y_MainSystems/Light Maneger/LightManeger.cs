using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana.MainSystems
{
    public class LightManeger
    {
        static LightManeger maneger;
        List<SceneLight> lights;

        public LightSettingData settingData;

        public static LightManeger GetInstance()
        {
            if (maneger == null)
            {
                maneger = new LightManeger();
            }

            return maneger;
        }

        public void Init()
        {
            this.lights = new List<SceneLight>();

            foreach (SceneLight light in settingData.lights)
            {
                this.lights.Add(light);
            }

        }

        public SceneLight GetLight(string lightName)
        {
            for (int i = 0; i < lights.Count; i++)
            {
                if (lights[i].lightName == lightName)
                {
                    return lights[i];
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
