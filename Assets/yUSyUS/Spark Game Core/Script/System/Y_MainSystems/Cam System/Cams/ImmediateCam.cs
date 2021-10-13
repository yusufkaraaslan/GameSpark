using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public class ImmediateCam : ICam
        {
            public override void initilaze(GameObject cam, Layout layout)
            {
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

            public void SetPose(ImmediateCamLayout l)
            {
                cam.transform.position = l.camPose.transform.position;

                if (l.useRot)
                {
                    cam.transform.rotation = l.camPose.transform.rotation;
                }
            }

            public override void UpdateCam()
            {

            }
        }
    }

}