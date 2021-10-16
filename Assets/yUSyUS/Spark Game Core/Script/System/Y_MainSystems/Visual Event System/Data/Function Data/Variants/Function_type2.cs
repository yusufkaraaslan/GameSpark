using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SparkGameCore.MainSystems
{
    public class Function_type2 : FunctionWorker
    {
        public Action<string> action;
        public string input;

        public Function_type2(Action<string> action, string input)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public override bool Work()
        {
            action(input);

            return true;
        }
    }
}