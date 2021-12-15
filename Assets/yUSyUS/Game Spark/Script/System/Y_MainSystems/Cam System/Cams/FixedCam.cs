using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    public class FixedCam : ICam
    {
        public override void initilaze(GameObject cam, SparkCameraLayout layout)
        {
            layout.initilaze();
            base.initilaze(cam, layout);

            Dictionary<string, object> tmp = layout.GetCamData();

            GameObject camPose;
            bool useRot;

            camPose = (GameObject)tmp["camPose"];
            useRot = (bool)tmp["useRot"];

            cam.transform.position = camPose.transform.position;

            if (useRot)
            {
                cam.transform.rotation = camPose.transform.rotation;
            }
        }

        public override void UpdateCam()
        {

        }
    }
}