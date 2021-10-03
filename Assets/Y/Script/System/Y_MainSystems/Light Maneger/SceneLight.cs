using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana.MainSystems
{
    public class SceneLight : MonoBehaviour
    {
        public string lightName;
        [SerializeField] Light sceneLight;

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

        public void SetAngle(Quaternion quaternion)
        {
            sceneLight.gameObject.transform.rotation = quaternion;
        }

        public Light GetLight()
        {
            return sceneLight;
        }

    }
}
