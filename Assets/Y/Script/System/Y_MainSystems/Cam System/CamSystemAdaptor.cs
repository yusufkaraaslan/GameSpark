using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class CamSystemAdaptor : MonoBehaviour
        {
            [SerializeField]
            GameObject[] cams;

            public void initilaze()
            {
                CamSystem.initilaze(cams);
            }
        }
    }

}