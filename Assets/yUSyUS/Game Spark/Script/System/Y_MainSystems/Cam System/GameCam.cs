using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    public class GameCam : MonoBehaviour
    {
        public string camName;
        ICam camAtr;

        public void SetICam(ICam atr, SparkCameraLayout layout)
        {
            atr.initilaze(gameObject, layout);
            camAtr = atr;
        }

        private void Update()
        {
            if (camAtr != null)
                camAtr.UpdateCam();
        }
    }

}