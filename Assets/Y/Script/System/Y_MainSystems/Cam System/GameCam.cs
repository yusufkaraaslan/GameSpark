using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class GameCam : MonoBehaviour
        {
            public string camName;
            ICam camAtr;

            public void SetICam(ICam atr, Layout layout)
            {
                atr.initilaze(gameObject, layout);
                camAtr = atr;
            }

            private void Update()
            {
                if (camAtr != null)
                    camAtr.UpdateCam();
            }
        }
    }

}