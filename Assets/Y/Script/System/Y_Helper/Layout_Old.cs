using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace Helper
    {
        public class Layout_Old : MonoBehaviour
        {
            public layoutPoint[] CamPlayPose;
            public layoutPoint CamWaitPose;
            public Transform[] objStartPos;

            [SerializeField]
            Collider boundCollider;

            public Vector3 MinBounds
            {
                get => boundCollider.bounds.min;
            }

            public Vector3 MaxBounds
            {
                get => boundCollider.bounds.max;
            }
        }
    }
}