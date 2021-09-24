using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  Yatana.MainSystems
{
    public class BasicFunction : FunctionOrder
    {
        public Action action;

        public override void Work()
        {
            action();

            isDone = true;
        }
    }
}
