using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore.MainSystems
{
    [System.Serializable]
    public class MoveOrder
    {
        public bool waitForMoveEnd;
        public float preDelay, postDelay, unitMoveTime, maxMoveTime, minMoveTime;
        public InterpType interpType;
        public RouteType routeType;
        public bool isLookAtTarget;
        [HideInInspector] public bool lockRotateAtYAxis;
        [HideInInspector] public Vector3 arcAxis;

        [HideInInspector]
        public Queue<Checkpoint> targetQ;
        [HideInInspector]
        public GameObject obj;

        public MoveOrder(MoveOrder moveOrder)
        {
            waitForMoveEnd = moveOrder.waitForMoveEnd;
            preDelay = moveOrder.preDelay;
            postDelay = moveOrder.postDelay;
            unitMoveTime = moveOrder.unitMoveTime;
            maxMoveTime = moveOrder.maxMoveTime;
            minMoveTime = moveOrder.minMoveTime;
            interpType = moveOrder.interpType;
            routeType = moveOrder.routeType;
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

        public void AddCheckPoint(Checkpoint checkpoint)
        {
            if (targetQ == null)
            {
                targetQ = new Queue<Checkpoint>();
            }

            targetQ.Enqueue(checkpoint);
        }

        public MoveOrder()
        {

        }
    }
}
