using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class BasicFollowCam : ICam
        {
            GameObject followObj;
            Vector3 offset;
            Quaternion rot;
            bool follow_x, follow_y, follow_z;
            float moveSpeed;
            bool rotImmediate;
            float rotSpeed;

            public override void initilaze(GameObject cam, Layout layout)
            {
                base.initilaze(cam, layout);

                Dictionary<string, object> tmp = layout.GetCamData();

                followObj = (GameObject)tmp["followObj"];
                offset = (Vector3)tmp["offset"];
                rot = (Quaternion)tmp["rot"];
                follow_x = (bool)tmp["follow_x"];
                follow_y = (bool)tmp["follow_y"];
                follow_z = (bool)tmp["follow_z"];
                moveSpeed = (float)tmp["moveSpeed"];
                rotImmediate = (bool)tmp["rotImmediate"];
                rotSpeed = (float)tmp["rotSpeed"];

                if (rotImmediate)
                {
                    cam.transform.rotation = rot;
                }
            }

            public override void UpdateCam()
            {
                Vector3 target = followObj.transform.position + offset;

                cam.transform.position = Vector3.MoveTowards
                        (cam.transform.position,
                        new Vector3((follow_x) ? target.x - offset.x : cam.transform.position.x,
                        (follow_y) ? target.y - offset.y : cam.transform.position.y,
                        (follow_z) ? target.z - offset.z : cam.transform.position.z)
                        , moveSpeed);

                if (!rotImmediate)
                {
                    cam.transform.rotation = Quaternion.RotateTowards
                            (cam.transform.rotation, rot, rotSpeed);
                }
            }
        }
    }

}