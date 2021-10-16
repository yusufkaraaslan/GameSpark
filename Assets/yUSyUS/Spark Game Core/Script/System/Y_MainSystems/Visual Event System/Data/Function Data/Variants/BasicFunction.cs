using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  SparkGameCore.MainSystems
{
    public class BasicFunction : FunctionWorker
    {
        Action action;

        public BasicFunction(Action action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override bool Work()
        {
            action();

            return true;
        }
    }
}
