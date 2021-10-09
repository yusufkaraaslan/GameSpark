using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        [System.Serializable]
        public class MoveOrder
        {
            public bool moveLock;
            public float preDelay, postDelay, unitMoveTime, maxMoveTime, minMoveTime;
            public InterpType interpType;
            public RouteType routeType;
            public bool isRotate;
            public bool isLookAtTarget;
            public bool lockRotateAtYAxis;
            public Vector3 arcAxis;

            [HideInInspector]
            public Queue<Checkpoint> targetQ;
            [HideInInspector]
            public GameObject obj;

            public MoveOrder(MoveOrder moveOrder)
            {
                moveLock = moveOrder.moveLock;
                preDelay = moveOrder.preDelay;
                postDelay = moveOrder.postDelay;
                unitMoveTime = moveOrder.unitMoveTime;
                maxMoveTime = moveOrder.maxMoveTime;
                minMoveTime = moveOrder.minMoveTime;
                interpType = moveOrder.interpType;
                routeType = moveOrder.routeType;
                isRotate = moveOrder.isRotate;
                isLookAtTarget = moveOrder.isLookAtTarget;
                lockRotateAtYAxis = moveOrder.lockRotateAtYAxis;
                arcAxis = moveOrder.arcAxis;
            }

            public float GetRealMoveTime(float moveDistance)
            {
                float res = moveDistance * unitMoveTime;

                if (maxMoveTime == minMoveTime)
                {
                    return maxMoveTime;
                }

                if (res < minMoveTime)
                {
                    res = minMoveTime;
                }
                else if (res > maxMoveTime)
                {
                    res = maxMoveTime;
                }

                return res;
            }

            public MoveOrder()
            {

            }
        }
    }
}
