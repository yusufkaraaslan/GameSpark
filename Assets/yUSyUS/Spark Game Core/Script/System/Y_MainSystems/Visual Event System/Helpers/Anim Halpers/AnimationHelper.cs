using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SparkGameCore.MainSystems
{
    public class AnimationHelper : HelperBase
    {
        AnimOrder animationOrder;
        Animator animator;
        AnimControllerProxy animControllerProxy;
        AnimState state = AnimState.PreWaiting;

        float passTime;
        bool isWaiting = false;

        public AnimationHelper(AnimOrder animOrder)
        {
            animationOrder = animOrder;
            animator = animationOrder.anim;
            animControllerProxy = animator.GetComponent<AnimControllerProxy>();
        }
        public override bool IsComplete()
        {
            if (animationOrder.animLock)
            {
                return state == AnimState.End;
            }

            return true;
        }
        private void Wait(float delay, AnimState animState)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                passTime = Time.time + delay;
            }
            else
            {
                if (Time.time >= passTime)
                {
                    state = animState;
                    isWaiting = false;
                }
            }
        }
        private void SetCondition()
        {
            //foreach (string x in animationOrder.boolCondition.Keys)
            //{
            //    animator.SetBool(x, animationOrder.boolCondition[x]);
            //}
            //foreach (string x in animationOrder.triggerCondition)
            //{
            //    animator.SetTrigger(x);
            //}
            //foreach (string x in animationOrder.intCondition.Keys)
            //{
            //    animator.SetInteger(x, animationOrder.intCondition[x]);
            //}

            foreach (var x in animationOrder.boolCondition)
            {
                animator.SetBool(x.key, x.value);
            }
            foreach (var x in animationOrder.triggerCondition)
            {
                animator.SetTrigger(x);
            }
            foreach (var x in animationOrder.intCondition)
            {
                animator.SetInteger(x.key, x.value);
            }
        }
        public override void Work()
        {
            switch (state)
            {
                case AnimState.PreWaiting:
                    if (animationOrder.preDelay > 0)
                        Wait(animationOrder.preDelay, AnimState.Start);
                    else
                        state = AnimState.Start;
                    break;
                case AnimState.Start:
                    SetCondition();
                    animControllerProxy.Begin();
                    state = AnimState.Running;
                    break;
                case AnimState.Running:
                    if (animControllerProxy.IsComplete == true)
                        state = AnimState.PostWaiting;
                    break;
                case AnimState.PostWaiting:
                    if (animationOrder.postDelay > 0)
                        Wait(animationOrder.postDelay, AnimState.End);
                    else
                        state = AnimState.End;
                    break;
                case AnimState.End:
                    break;
                default:
                    break;
            }
        }
        
    }

}

public enum AnimState
{
    PreWaiting, Start, Running, PostWaiting, End
}