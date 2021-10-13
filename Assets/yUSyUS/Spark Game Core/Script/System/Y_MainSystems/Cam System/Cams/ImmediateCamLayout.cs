using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        public class ImmediateCamLayout : Layout
        {
            public GameObject camPose;
            public bool useRot;

            private void Start()
            {
                initilaze();
            }

            void initilaze()
            {
                AddGameObject("camPose", camPose);
                AddBool("useRot", useRot);
            }
        }
    }

}