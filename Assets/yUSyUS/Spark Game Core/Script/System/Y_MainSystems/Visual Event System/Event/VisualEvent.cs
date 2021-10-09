using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class VisualEvent
        {
            EventState state;

            List<VisualEventData> events;
            int eventIndex;

            bool isWaiting;
            float passTime;

            List<MoveHelper> moveHelpers;
            List<AnimationHelper> animHelpers;
            List<FunctionHelper> functionHelpers;

            public VisualEvent(List<VisualEventData> events)
            {
                this.events = events;

                eventIndex = 0;

                moveHelpers = new List<MoveHelper>();
                animHelpers = new List<AnimationHelper>();
                functionHelpers = new List<FunctionHelper>();

                state = EventState.init;
            }

            public VisualEvent()
            {

            }

            public bool IsComplete()
            {
                return state == EventState.Complete;
            }

            public void work()
            {
                switch (state)
                {
                    case EventState.init:

                        InitilazeEvent();
                        state = EventState.PreWaiting;
                        break;

                    case EventState.PreWaiting:

                        if (events[eventIndex].preDelay > 0)
                        {
                            if (HoldWorking(events[eventIndex].preDelay))
                            {
                                state = EventState.Playing;
                            }
                        }
                        else
                        {
                            state = EventState.Playing;
                        }

                        break;

                    case EventState.Playing:

                        PlayOrders();

                        break;

                    case EventState.PosWaiting:

                        if (events[eventIndex].posDelay > 0)
                        {
                            if (HoldWorking(events[eventIndex].preDelay))
                            {
                                state = EventState.Ending;
                            }
                        }
                        else
                        {
                            state = EventState.Ending;
                        }

                        break;

                    case EventState.Ending:

                        EndEvent();

                        break;

                    case EventState.Complete:
                        break;
                }
            }

            public void FinishEvent()
            {
                state = EventState.Complete;
            }

            bool HoldWorking(float waitTime)
            {
                if (!isWaiting)
                {
                    isWaiting = true;
                    passTime = Time.time + waitTime;
                }
                else
                {
                    if (Time.time >= passTime)
                    {
                        isWaiting = false;

                        return true;
                    }
                }

                return false;
            }

            void InitilazeEvent()
            {
                VisualEventData curr = events[eventIndex];

                if (curr.GetAnim() != null)
                {
                    InitAnim(curr.GetAnim());
                }

                if (curr.GetMove() != null)
                {
                    InitMove(curr.GetMove());
                }

                if (curr.GetFunctions() != null)
                {
                    InitFunction(curr.GetFunctions());
                }
            }

            void InitAnim(AnimData orderData)
            {
                List<AnimOrder> animOrders = orderData.animOrders;

                foreach (AnimOrder x in animOrders)
                {
                    animHelpers.Add(new AnimationHelper(x));
                }
            }

            void InitMove(MoveData orderData)
            {
                List<MoveOrder> moveOrders = orderData.moveOrders;

                foreach (MoveOrder x in moveOrders)
                {
                    moveHelpers.Add(new MoveHelper(x));
                }
            }

            void InitFunction(FunctionData orderData)
            {
                List<FunctionOrder> functionOrders = orderData.functions;

                foreach (FunctionOrder x in functionOrders)
                {
                    functionHelpers.Add(new FunctionHelper(x));
                }
            }

            void PlayOrders()
            {
                bool res = true;
                bool visualsDone = false;

                foreach (MoveHelper x in moveHelpers)
                {
                    x.Work();

                    if (res && !x.IsComplete())
                    {
                        res = false;
                    }

                }

                foreach (AnimationHelper x in animHelpers)
                {
                    x.Work();

                    if (res && !x.IsComplete())
                    {
                        res = false;
                    }
                }

                foreach (FunctionHelper x in functionHelpers)
                {
                    if (res && x.GetWorkState() == EventWorkPhase.PreActivate && !x.IsComplete())
                    {
                        res = false;
                    }
                }

                if (res)
                {
                    visualsDone = true;
                }

                foreach (FunctionHelper x in functionHelpers)
                {
                    if (visualsDone)
                    {
                        x.CompleteEventFunction();
                    }

                    x.Work();

                    if (!x.IsComplete())
                    {
                        res = false;
                    }
                }

                if (res)
                {
                    state = EventState.PosWaiting;
                }

            }

            void EndEvent()
            {
                ++eventIndex;


                if (events.Count <= eventIndex)
                {
                    state = EventState.Complete;
                }
                else
                {
                    state = EventState.init;
                }

            }

        }


        public enum EventState
        {
            init, PreWaiting, Playing, PosWaiting, Ending, Complete
        }
    }
}
