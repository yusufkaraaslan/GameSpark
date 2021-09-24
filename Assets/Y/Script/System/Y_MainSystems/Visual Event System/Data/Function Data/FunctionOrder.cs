using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public abstract class FunctionOrder
        {
            public EventWorkPhase workPhase;
            public float preDelay, posDelay;

            protected bool isDone = false;

            public bool IsComplete()
            {
                return isDone;
            }

            public abstract void Work();
        }

        public enum EventWorkPhase
        {
            PreActivate, PostActivate
        }
    }
}
