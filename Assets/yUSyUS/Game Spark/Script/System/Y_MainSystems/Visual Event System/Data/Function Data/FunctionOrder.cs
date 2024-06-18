using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    [System.Serializable]
    public class FunctionOrder
    {
        [SerializeField] string functionTag; // Only for easy readability on editor

        public EventWorkPhase workPhase;
        public float preDelay, posDelay;

        [HideInInspector] public FunctionWorker worker;

        bool isDone = false;

        public FunctionOrder()
        {

        }

        public FunctionOrder(FunctionOrder other)
        {
            workPhase = other.workPhase;
            preDelay = other.preDelay;
            posDelay = other.posDelay;

            worker = null;
        }

        public bool IsComplete()
        {
            if (isDone)
            {
                isDone = false;
                return true;
            }

            return false;
        }

        public void Work()
        {
            if (worker.Work())
            {
                isDone = true;
            }
        }
    }

    public enum EventWorkPhase
    {
        PreActivate, PostActivate
    }
}
