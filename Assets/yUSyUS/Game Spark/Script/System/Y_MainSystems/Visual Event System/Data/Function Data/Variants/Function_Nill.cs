using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GameSpark
{
    public class Function_Nill : FunctionWorker
    {
        float completeTime = -1;
        float completeDelay = 3;

        public Function_Nill(float completeDelay)
        {
            this.completeTime = -1;
            this.completeDelay = completeDelay;
        }

        public override bool Work()
        {
            if (completeTime == -1)
            {
                completeTime = Time.time + completeDelay;
            }
            else if (Time.time > completeTime)
            {
                return true;
            }

            return false;
        }
    }
}
