﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    public abstract class ICam
    {
        protected GameObject cam;

        public virtual void initilaze(GameObject cam, Layout layout)
        {
            this.cam = cam;
        }

        public abstract void UpdateCam();
    }
}