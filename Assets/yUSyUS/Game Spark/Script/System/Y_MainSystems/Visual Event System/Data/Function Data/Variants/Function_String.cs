using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GameSpark
{
    public class Function_String : FunctionWorker
    {
        public Func<string, bool> action;
        public string input;

        public Function_String(Func<string, bool> action, string input)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        public override bool Work()
        {
            return action(input);
        }
    }
}