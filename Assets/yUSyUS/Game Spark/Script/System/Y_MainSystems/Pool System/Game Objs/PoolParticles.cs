using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSpark
{
    public class PoolParticles : PoolObject
    {
        ParticleSystem particle;

        bool loopParticle;
        float completeTime;
        float destrotTime;

        public override void initilaze()
        {
            base.initilaze();
            particle = GetComponent<ParticleSystem>();

            loopParticle = particle.main.loop;
            completeTime = particle.main.duration;
        }

        public override void SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
        {
            base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);

            obj.SetActive(true);
            destrotTime = Time.time + completeTime;

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
