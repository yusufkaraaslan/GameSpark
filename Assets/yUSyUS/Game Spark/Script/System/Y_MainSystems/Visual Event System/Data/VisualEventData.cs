using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark.Plus;

namespace GameSpark
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

