using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameSpark
{
    public class Function_Vector2 : FunctionWorker
    {
        public Func<Vector2,bool> action;
        public Vector2 input;

        public Function_Vector2(Func<Vector2, bool> action, Vector2 input)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.input = input;
        }

        public override bool Work()
        {
            return action(input);
        }
    }

}