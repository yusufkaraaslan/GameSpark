using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class MoveHelper : HelperBase
        {
            MoveLifeState state;
            MoveOrder moves;
            float currTime, realMoveTime;
            Checkpoint target;
            Vector3 startPos;

            bool isWaiting;
            float passTime;

            bool checkPointWait = false;
            float newCheckPointStartTime;
            float checkPointDelay = 0.03f;

            bool moveComplete = false;
            bool rotComplete = false;
            float rotSpeed = 80f;

            Vector3 shadowPos;

            public MoveHelper(MoveOrder moves)
            {
                this.moves = moves;
                isWaiting = false;
                state = MoveLifeState.PreWaiting;
            }

            public override bool IsComplete()
            {
                if (moves.moveLock)
                {
                    return state == MoveLifeState.End;
                }

                return true;
            }

            public override void Work()
            {
                switch (state)
                {
                    case MoveLifeState.PreWaiting:

                        if (moves.preDelay > 0)
                        {
                            if (HoldWorking(moves.preDelay))
                            {
                                state = MoveLifeState.Start;
                            }
                        }
                        else
                        {
                            state = MoveLifeState.Start;
                        }

                        break;

                    case MoveLifeState.Start:

                        initMove();
                        checkPointWait = false;
                        state = MoveLifeState.Moving;

                        break;

                    case MoveLifeState.Moving:

                        if (!checkPointWait && !moveComplete)
                        {
                            Move();
                        }

                        LookTarget();

                        if (checkPointWait)
                        {
                            if (Time.time >= newCheckPointStartTime)
                            {
                                state = MoveLifeState.Start;
                            }
                        }
                        else
                        {
                            if (Vector3.Distance(moves.obj.transform.position, target.TarPos) < 0.1f ||
                                currTime >= realMoveTime)
                            {
                                moveComplete = true;

                                if (rotComplete)
                                {
                                    if (moves.targetQ != null)
                                    {
                                        if (moves.targetQ.Count > 0)
                                        {
                                            if (moves.targetQ.Peek().TarPos.x != target.TarPos.x)
                                            {
                                                checkPointWait = true;
                                                newCheckPointStartTime = Time.time + checkPointDelay;
                                                return;
                                            }
                                            else
                                            {
                                                state = MoveLifeState.Start;
                                                return;
                                            }
                                        }
                                    }

                                    moves.obj.transform.position = target.TarPos;
                                    state = MoveLifeState.PostWaiting;
                                }
                            }
                        }

                        break;

                    case MoveLifeState.PostWaiting:

                        if (moves.postDelay > 0)
                        {
                            if (HoldWorking(moves.postDelay))
                            {
                                state = MoveLifeState.End;
                            }
                        }
                        else
                        {
                            state = MoveLifeState.End;
                        }

                        break;

                    case MoveLifeState.End:
                        break;
                }
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

            void initMove()
            {
                if (moves.targetQ == null || moves.targetQ.Count <= 0)
                {
                    throw new System.Exception("Move Target Error: " + (moves == null ? "null targetQ" : "empty targetQ"));
                }

                //Vector3 oldTarget = target;
                rotComplete = !moves.isLookAtTarget;
                moveComplete = false;
                target = moves.targetQ.Dequeue();

                CalculateMove();
            }

            void CalculateMove()
            {
                currTime = 0;

                startPos = moves.obj.transform.position;
                shadowPos = moves.obj.transform.position;

                //moves.unitMoveTime = 

                realMoveTime = moves.GetRealMoveTime(Mathf.Abs((target.TarPos - moves.obj.transform.position).magnitude));

                moves.arcAxis = target.Arc;
                rotSpeed = target.RotState;
                moves.lockRotateAtYAxis = target.LockYAxis;

            }

            void LookTarget()
            {
                if (!moves.isLookAtTarget)
                {
                    return;
                }

                Vector3 lTargetDir = target.LookPos - moves.obj.transform.position;

                if (moves.lockRotateAtYAxis)
                {
                    lTargetDir.y = 0.0f;
                }

                Quaternion oldRot = moves.obj.transform.rotation;
                moves.obj.transform.rotation = Quaternion.RotateTowards(moves.obj.transform.rotation, Quaternion.LookRotation(lTargetDir),
                    Time.deltaTime * rotSpeed);

                if (oldRot == moves.obj.transform.rotation)
                {
                    rotComplete = true;
                }
                else
                {
                    rotComplete = false;
                }
            }

            void Move()
            {
                Vector3 currPos = moves.obj.transform.position;
                currTime += Time.deltaTime;

                float t = Mathf.Clamp(currTime / realMoveTime, 0f, 1f);

                Vector3 r = new Vector3();
                float rot;

                switch (moves.interpType)
                {
                    case InterpType.Linear:
                        break;
                    case InterpType.EaseOut:
                        t = Mathf.Sin(t * Mathf.PI * 0.5f);
                        break;
                    case InterpType.EaseIn:
                        t = 1 - Mathf.Cos(t * Mathf.PI * 0.5f);
                        break;
                    case InterpType.SmoothStep:
                        t = t * t * (3 - 2 * t);
                        break;
                    case InterpType.SmootherStep:
                        t = t * t * t * (t * (t * 6 - 15) + 10);
                        break;
                    default:
                        break;
                }

                switch (moves.routeType)
                {
                    case RouteType.Lineer:
                        moves.obj.transform.position = Vector3.Lerp(currPos, target.TarPos, t);
                        break;

                    case RouteType.Spiral:
                        r = Vector3.Lerp(currPos, target.TarPos, t) - startPos;
                        rot = Mathf.Lerp(180, 360, t) * Mathf.PI / 180;

                        if (startPos.x < target.TarPos.x)
                        {
                            rot = Mathf.Lerp(180, 0, t) * Mathf.PI / 180;
                        }
                        else
                        {
                            rot = Mathf.Lerp(180, 360, t) * Mathf.PI / -180;
                        }

                        Vector3 tar = startPos + new Vector3(r.x * Mathf.Cos(rot) - r.y * Mathf.Sin(rot),
                            r.x * Mathf.Sin(rot) + r.y * Mathf.Cos(rot),
                            0);

                        moves.obj.transform.position = tar;

                        if (startPos.x > target.TarPos.x)
                        {
                            moves.obj.transform.rotation = Quaternion.Euler(0, 0, ((rot * 180 / Mathf.PI)));
                        }
                        else
                        {
                            moves.obj.transform.rotation = Quaternion.Euler(0, 0, (rot * 180 / Mathf.PI) - 180);
                        }

                        break;

                    case RouteType.Arc:
                        /*
                        r = Vector3.Lerp(currPos, target.tarPos, t);

                        if (t < 0.5f)
                        {
                            r += moves.arcAxis * 0.01f;
                        }

                        moves.obj.transform.position = r;
                        */
                        shadowPos = Vector3.Lerp(startPos, target.TarPos, t) - startPos;

                        if (currTime <= realMoveTime / 2)
                        {
                            r = shadowPos + moves.arcAxis * 2 * (currTime / realMoveTime);
                        }
                        else
                        {
                            r = shadowPos + moves.arcAxis * 2 * (1 - (currTime / realMoveTime));
                        }

                        moves.obj.transform.position = r + startPos;
                        break;

                    default:
                        break;
                }

            }


        }

        public enum MoveLifeState
        {
            PreWaiting, Start, Moving, MoveEnd, PostWaiting, End
        }

        public enum InterpType
        {
            Linear,
            EaseOut,
            EaseIn,
            SmoothStep,
            SmootherStep
        }

        public enum RouteType
        {
            Lineer, Spiral, Arc
        }
    }
}
