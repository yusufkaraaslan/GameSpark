using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.MainSystems
{
    public class SceneLight : MonoBehaviour
    {
        public string lightName;
        Light sceneLight;

        public void Initilaze()
        {
            sceneLight = GetComponent<Light>();
        }

        public void LightOn()
        {
            sceneLight.enabled = true;
        }

        public void LightOff()
        {
            sceneLight.enabled = false;
        }

        public void SetColor(Color color)
        {
            sceneLight.color = color;
        }

        public void SetIntensity(float intensity)
        {
            sceneLight.intensity = intensity;
        }

        public void SetRange(float range)
        {
            sceneLight.range = range;
        }

        public void SetAngle(Quaternion quaternion)
        {
            sceneLight.gameObject.transform.rotation = quaternion;
        }
        public void SetAngle(GameObject lookObj)
        {
            sceneLight.gameObject.transform.LookAt(lookObj.transform);
        }

        public Light GetLight()
        {
            return sceneLight;
        }

    }
}
