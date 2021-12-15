using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.Plus
{
    public class FunctionHelper
    {
        FunctionOrder functionOrder;
        FunctionState state;

        bool othersComplete;
        bool isWaiting = false;
        bool preWorkDone;
        float passTime;

        public FunctionHelper(FunctionOrder function)
        {
            functionOrder = function;
            othersComplete = false;
            preWorkDone = false;
        }

        public EventWorkPhase GetWorkState()
        {
            return functionOrder.workPhase;
        }

        public void CompleteEventFunction()
        {
            othersComplete = true;
        }

        public bool IsComplete()
        {
            bool res = false;

            if (functionOrder.workPhase == EventWorkPhase.PreActivate)
            {
                res = preWorkDone;
            }

            if (functionOrder.workPhase == EventWorkPhase.PostActivate && state == FunctionState.PostEnd)
            {
                res = true;
            }

            return res;
        }

        public void Work()
        {
            switch (state)
            {
                case FunctionState.PreWaiting:
                    if (functionOrder.preDelay > 0)
                        Wait(functionOrder.preDelay, FunctionState.Start);
                    else
                        state = FunctionState.Start;
                    break;
                case FunctionState.Start:

                    if (functionOrder.workPhase == EventWorkPhase.PreActivate)
                        functionOrder.Work();

                    if (functionOrder.IsComplete() || functionOrder.workPhase == EventWorkPhase.PostActivate)
                    {
                        state = FunctionState.Running;
                    }

                    break;
                case FunctionState.Running:

                    preWorkDone = true;
                    
                    if (othersComplete == true)
                        state = FunctionState.End;
                    
                    break;
                case FunctionState.End:
                    
                    if (functionOrder.workPhase == EventWorkPhase.PostActivate)
                        functionOrder.Work();

                    if (functionOrder.IsComplete())
                    {
                        state = FunctionState.PostEnd;
                    }

                    break;
                case FunctionState.PostWaiting:
                    
                    if (functionOrder.posDelay > 0)
                        Wait(functionOrder.posDelay, FunctionState.PostEnd);
                    else
                        state = FunctionState.PostEnd;
                    
                    break;
                case FunctionState.PostEnd:
                    break;
                default:
                    break;
            }
        }

        private void Wait(float delay, FunctionState funcState)
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
                    state = funcState;
                    isWaiting = false;
                }
            }
        }

    }
}

public enum FunctionState
{
    PreWaiting, Start, Running, PostWaiting, End, PostEnd
}