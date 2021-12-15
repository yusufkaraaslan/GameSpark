using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    public abstract class ICam
    {
        protected GameObject cam;

        public virtual void initilaze(GameObject cam, SparkCameraLayout layout)
        {
            this.cam = cam;
        }

        public abstract void UpdateCam();
    }
}