using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SparkGameCore.MainSystems;

namespace SparkGameCore
{
    public class VisualEventData
    {
        MoveData moveDat;
        AnimData animDat;
        FunctionData functionDat;
        public float preDelay, posDelay;

        public void SetMoveData(MoveData move)
        {
            moveDat = move;
        }

        public void SetAnimData(AnimData anim)
        {
            animDat = anim;
        }

        public void SetFunctionData(FunctionData f)
        {
            functionDat = f;
        }

        public void SetPreDelay(float time)
        {
            preDelay = time;
        }

        public void setPosDelay(float time)
        {
            posDelay = time;
        }

        public MoveData GetMove()
        {
            return moveDat;
        }

        public AnimData GetAnim()
        {
            return animDat;
        }

        public FunctionData GetFunctions()
        {
            return functionDat;
        }

    }
}

