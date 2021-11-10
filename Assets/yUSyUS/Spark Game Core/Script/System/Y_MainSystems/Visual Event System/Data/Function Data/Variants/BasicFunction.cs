using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace  SparkGameCore
{
    public class BasicFunction : FunctionWorker
    {
        Func<bool> action;

        public BasicFunction(Func<bool> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public override bool Work()
        {
            return action();
        }
    }
}
