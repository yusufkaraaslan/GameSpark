using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    public class BasicFollowCam : ICam
    {
        GameObject followObj;
        GameObject lookObj;

        bool follow_x, follow_y, follow_z;
        bool look_x, look_y, look_z;

        float moveSpeed;
        bool lookImmediate, rotImmediateOnInit;
        float rotSpeed;

        public override void initilaze(GameObject cam, SparkCameraLayout layout)
        {
            layout.initilaze();
            base.initilaze(cam, layout);

            Dictionary<string, object> tmp = layout.GetCamData();

            followObj = (GameObject)tmp["followObj"];
            lookObj = (GameObject)tmp["lookObj"];

            follow_x = (bool)tmp["follow_x"];
            follow_y = (bool)tmp["follow_y"];
            follow_z = (bool)tmp["follow_z"];

            look_x = (bool)tmp["look_x"];
            look_y = (bool)tmp["look_y"];
            look_z = (bool)tmp["look_z"];

            moveSpeed = (float)tmp["moveSpeed"];
            lookImmediate = (bool)tmp["lookImmediate"];
            rotImmediateOnInit = (bool)tmp["rotImmediateOnInit"];
            rotSpeed = (float)tmp["rotSpeed"];

            if (rotImmediateOnInit)
            {
                cam.transform.LookAt(lookObj.transform);
            }
        }

        public override void UpdateCam()
        {
            Vector3 target = followObj.transform.position;

            cam.transform.position = Vector3.MoveTowards
                    (cam.transform.position,
                    new Vector3
                        ((follow_x) ? target.x : cam.transform.position.x,
                        (follow_y) ? target.y : cam.transform.position.y,
                        (follow_z) ? target.z : cam.transform.position.z)
                        , moveSpeed);

            if (!lookImmediate)
            {
                cam.transform.rotation = Quaternion.RotateTowards
                        (cam.transform.rotation, new Quaternion(
                            look_x ? lookObj.transform.rotation.x : cam.transform.rotation.x,
                            look_y ? lookObj.transform.rotation.y : cam.transform.rotation.y,
                            look_z ? lookObj.transform.rotation.z : cam.transform.rotation.z,
                            lookObj.transform.rotation.w), rotSpeed);
            }
            else
            {
                cam.transform.LookAt(new Vector3(
                            look_x ? lookObj.transform.position.x : cam.transform.position.x + cam.transform.forward.x,
                            look_y ? lookObj.transform.position.y : cam.transform.position.y + cam.transform.forward.y,
                            look_z ? lookObj.transform.position.z : cam.transform.position.z + cam.transform.forward.z));
            }
        }
    }
}