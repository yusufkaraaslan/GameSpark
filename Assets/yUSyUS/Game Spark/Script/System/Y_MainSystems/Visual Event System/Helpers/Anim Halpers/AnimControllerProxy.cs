using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark.MainSystems
{
    public class AnimControllerProxy : MonoBehaviour
    {
        public bool IsComplete { get; private set; }
        public void Begin()
        {
            IsComplete = false;
        }

        public void End()
        {
            IsComplete = true;
        }
    }

}
