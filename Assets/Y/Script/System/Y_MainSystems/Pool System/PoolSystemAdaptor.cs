using UnityEngine;
using Yatana.MainSystems;

namespace MainSystems
{
    public class PoolSystemAdaptor : MonoBehaviour
    {
        [SerializeField]
        GameObject[] objSamples;
        public void Initialize()
        {
            PoolSystem.initilaze(objSamples);
        }
    }
}
