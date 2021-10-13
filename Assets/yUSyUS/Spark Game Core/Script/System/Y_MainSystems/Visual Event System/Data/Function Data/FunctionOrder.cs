using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore.MainSystems
{
    [System.Serializable]
    public class FunctionOrder
    {
        [SerializeField] string functionTag; // for easy readablty 

        public EventWorkPhase workPhase;
        public float preDelay, posDelay;

        [HideInInspector] public FunctionWorker worker;

        bool isDone = false;

        public bool IsComplete()
        {
            return isDone;
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
