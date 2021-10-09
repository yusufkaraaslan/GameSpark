using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Yatana.MainSystems
{
    public class Function_type2 : FunctionWorker
    {
        public Action<string> action;
        public string input;

        public override bool Work()
        {
            action(input);

            return true;
        }
    }
}