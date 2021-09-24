using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

namespace Y_Generators
{
    public abstract class BaseGenerator : MonoBehaviour
    {
        protected bool isGeneratorOn;
        [SerializeField]
        protected GameObject[] spawnPoint;
        [SerializeField]
        protected bool useRotation, useScale;
        protected PoolSystem pool;
        protected List<PoolObj> objsInUse;
        [SerializeField]
        protected string[] objNames;
        protected bool manualGenerate;
        protected float spawnTime;
        protected float randomPercent;
        float nextGenerateTime;

        public virtual void GeneratorOn()
        {
            isGeneratorOn = true;
            nextGenerateTime = Time.time + spawnTime * Random.Range(1 - randomPercent, 1 + randomPercent);
        }

        public virtual void GeneratorOff()
        {
            isGeneratorOn = false;
        }

        public virtual void initilaze()
        {
            isGeneratorOn = false;
            objsInUse = new List<PoolObj>();
            pool = PoolSystem.GetInstance();
        }

        public abstract void Generate();

        public virtual void ClearGenerator()
        {
            for (int i = 0; i < objsInUse.Count; i++)
            {
                objsInUse[i].DespawnObj();
            }

            objsInUse.Clear();
        }

        private void Update()
        {
            if(isGeneratorOn && !manualGenerate)
            {
                if(nextGenerateTime <= Time.time)
                {
                    Generate();
                    nextGenerateTime = Time.time + spawnTime * Random.Range(1 - randomPercent, 1 + randomPercent);
                }
            }
        }

    }
}
