using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  SparkGameCore.MainSystems
{
    public class Function_Nill : FunctionWorker
    {
        bool waitDone;
        float destroyTime = -1;
        float destroyDelay = 3;

        public override bool Work()
        {
            if (destroyTime == -1)
            {
                destroyTime = Time.time + destroyDelay;
            }
            else if (Time.time <= destroyTime)
            {
                return true;
            }

            return false;
        }
    }
}
