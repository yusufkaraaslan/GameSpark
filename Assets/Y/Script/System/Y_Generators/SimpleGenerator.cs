using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Y_Generators
{
    public class SimpleGenerator : BaseGenerator
    {
        public override void Generate()
        {
            GameObject pos = spawnPoint[Random.Range(0, 500) % spawnPoint.Length];
            int objInd = Random.Range(0, 500) % objNames.Length;
            objsInUse.Add(pool.GetObj(objNames[objInd], pos, useRotation, false, useScale));
        }
    }
}
