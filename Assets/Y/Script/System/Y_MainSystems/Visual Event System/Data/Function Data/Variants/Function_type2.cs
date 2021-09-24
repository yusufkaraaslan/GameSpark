using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Yatana.MainSystems
{
    public class Function_type2 : FunctionOrder
    {
        public Action<string> action;
        public string input;

        public override void Work()
        {
            action(input);

            isDone = true;
        }
    }
}