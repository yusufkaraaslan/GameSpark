using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yatana
{
    namespace MainSystems
    {
        public class PoolParticles : PoolObj
        {
            [SerializeField]
            bool loopParticle;
            [SerializeField]
            float completeTime;
            float destrotTime;

            public override bool SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
            {
                bool res = base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);

                if (res)
                {
                    obj.SetActive(true);
                    destrotTime = Time.time + completeTime;
                }

                return res;
            }

            public override void DespawnObj(bool restartObj = true)
            {
                base.DespawnObj(restartObj);

                obj.SetActive(false);
            }

            void Update()
            {
                if (!loopParticle && inUse)
                {
                    if (Time.time >= destrotTime)
                    {
                        DespawnObj();
                    }
                }
            }
        }
    }
}
