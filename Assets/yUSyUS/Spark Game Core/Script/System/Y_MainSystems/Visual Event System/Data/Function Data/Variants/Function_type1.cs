using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SparkGameCore.MainSystems
{
    public class Function_type1 : FunctionWorker
    {
        public Action<Vector2> action;
        public Vector2 input;

        public Function_type1(Action<Vector2> action, Vector2 input)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.input = input;
        }

        public override bool Work()
        {
            action(input);

            return true;
        }
    }

}