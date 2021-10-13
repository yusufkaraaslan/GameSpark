using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public class BasicFollowCamLayout : Layout
        {
            [SerializeField]
            GameObject followObj;
            [SerializeField]
            GameObject lookObj;

            [SerializeField]
            bool follow_x, follow_y, follow_z;
            [SerializeField]
            bool look_x, look_y, look_z;

            [SerializeField]
            float moveSpeed;
            [SerializeField]
            bool lookImmediate, rotImmediateOnInit;
            [SerializeField]
            float rotSpeed;

            private void Start()
            {
                followObj.SetActive(false);
                lookObj.SetActive(false);
            }

            public override void initilaze()
            {
                AddGameObject("followObj", followObj);
                AddGameObject("lookObj", lookObj);

                AddBool("follow_x", follow_x);
                AddBool("follow_y", follow_y);
                AddBool("follow_z", follow_z);

                AddBool("look_x", look_x);
                AddBool("look_y", look_y);
                AddBool("look_z", look_z);

                AddFloat("moveSpeed", moveSpeed);
                AddBool("lookImmediate", lookImmediate);
                AddBool("rotImmediateOnInit", rotImmediateOnInit);
                AddFloat("rotSpeed", rotSpeed);
            }

        }
    }

}