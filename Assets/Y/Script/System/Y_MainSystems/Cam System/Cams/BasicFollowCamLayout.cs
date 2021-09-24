using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class BasicFollowCamLayout : Layout
        {
            [SerializeField]
            GameObject followObj;
            [SerializeField]
            Vector3 offset;
            [SerializeField]
            Quaternion rot;
            [SerializeField]
            bool follow_x, follow_y, follow_z;
            [SerializeField]
            float moveSpeed;
            [SerializeField]
            bool rotImmediate;
            [SerializeField]
            float rotSpeed;

            private void Start()
            {
                initilaze();
            }

            public void initilaze()
            {
                AddGameObject("followObj", followObj);
                AddVector3("offset", offset);
                AddQuaternion("rot", rot);
                AddBool("follow_x", follow_x);
                AddBool("follow_y", follow_y);
                AddBool("follow_z", follow_z);
                AddFloat("moveSpeed", moveSpeed);
                AddBool("rotImmediate", rotImmediate);
                AddFloat("rotSpeed", rotSpeed);
            }

        }
    }

}