using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Yatana.MainSystems
{
    public class Function_type1 : FunctionOrder
    {
        public Action<Vector2> action;
        public Vector2 input;

        public override void Work()
        {
            action(input);

            isDone = true;
        }
    }

}