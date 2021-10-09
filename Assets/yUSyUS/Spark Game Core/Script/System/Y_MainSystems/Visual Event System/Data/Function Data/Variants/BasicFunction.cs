using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  Yatana.MainSystems
{
    public class BasicFunction : FunctionWorker
    {
        public Action action;

        public override bool Work()
        {
            action();

            return true;
        }
    }
}
