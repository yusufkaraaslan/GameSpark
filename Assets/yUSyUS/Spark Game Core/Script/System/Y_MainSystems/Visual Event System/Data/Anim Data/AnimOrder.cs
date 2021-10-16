using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore
{
    namespace MainSystems
    {
        [System.Serializable]
        public class AnimOrder
        {
            public bool waitForAnimEnd;
            public float preDelay, postDelay;

            public List<string> triggerCondition;
            public List<BoolCondition> boolCondition;
            public List<IntCondition> intCondition;
            [HideInInspector]
            public Animator anim;

            public AnimOrder()
            {
                triggerCondition = new List<string>();
                boolCondition = new List<BoolCondition>();
                intCondition = new List<IntCondition>();
            }

            public AnimOrder(AnimOrder animOrder)
            {
                waitForAnimEnd = animOrder.waitForAnimEnd;
                preDelay = animOrder.preDelay;
                postDelay = animOrder.postDelay;
                waitForAnimEnd = animOrder.waitForAnimEnd;
                waitForAnimEnd = animOrder.waitForAnimEnd;
                waitForAnimEnd = animOrder.waitForAnimEnd;

                triggerCondition = animOrder.triggerCondition;
                boolCondition = animOrder.boolCondition;
                intCondition = animOrder.intCondition;

                anim = null;
            }

        }

        [System.Serializable]
        public class BoolCondition
        {
            public string key;
            public bool value;
        }
        [System.Serializable]
        public class IntCondition
        {
            public string key;
            public int value;
        }
    }
}
