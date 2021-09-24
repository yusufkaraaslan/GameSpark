using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Yatana.MainSystems
{
    public class Function_Nill : FunctionOrder
    {
        bool waitDone;
        float destroyTime = -1;
        float destroyDelay = 3;

        public override void Work()
        {
            if (destroyTime == -1)
            {
                destroyTime = Time.time + destroyDelay;
            }
            else if (Time.time <= destroyTime)
            {
                waitDone = true;
            }

            isDone = waitDone;
        }
    }
}
