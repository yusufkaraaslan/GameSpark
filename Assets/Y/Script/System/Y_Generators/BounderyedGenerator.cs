using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MainSystems;

namespace Y_Generators
{
    public class BounderyedGenerator : BaseGenerator
    {
        [SerializeField]
        bool fillSpace;
        [SerializeField]
        Vector3 axisStep;
        [SerializeField]
        Vector3 stepRandomPercent;

        Vector3 minPoint, maxPoint;

        public override void initilaze()
        {
            base.initilaze();

            Vector3 pointA;
            Vector3 pointB;

            try
            {
                pointA = spawnPoint[0].transform.position;
                pointB = spawnPoint[1].transform.position;
            }
            catch (System.Exception)
            {
                Debug.LogError("Boundery need 2 point: spawnPoint[0] and spawnPoint[1].");
                throw;
            }

            minPoint = new Vector3(Mathf.Min(pointA.x, pointB.x), Mathf.Min(pointA.y, pointB.y), Mathf.Min(pointA.z, pointB.z));
            maxPoint = new Vector3(Mathf.Max(pointA.x, pointB.x), Mathf.Max(pointA.y, pointB.y), Mathf.Max(pointA.z, pointB.z));
        }

        public override void Generate()
        {
            Vector3 pos = minPoint, scale = Vector3.one;
            Quaternion rot = new Quaternion();
            int objInd;
            int spawnCount = 0;

            if (fillSpace)
            {

                if (axisStep.x > 0)
                {
                    spawnCount = Mathf.Max(spawnCount, (int)((maxPoint.x - minPoint.x) / axisStep.x));
                }

                if (axisStep.y > 0)
                {
                    spawnCount = Mathf.Max(spawnCount, (int)((maxPoint.y - minPoint.y) / axisStep.y));
                }

                if (axisStep.z > 0)
                {
                    spawnCount = Mathf.Max(spawnCount, (int)((maxPoint.z - minPoint.z) / axisStep.z));
                }

                if (spawnCount == 0)
                {
                    Debug.LogError("fillSpace = true can't be used without at least one non zero field in asixStep.");
                    return;
                }

            }
            else
            {
                pos = new Vector3(Random.Range(minPoint.x, maxPoint.x), Random.Range(minPoint.y, maxPoint.y), Random.Range(minPoint.z, maxPoint.z));
                objInd = Random.Range(0, 500) % objNames.Length;
                spawnCount = 1;
            }


            for (int i = 0; i < spawnCount; i++)
            {
                if (fillSpace)
                {
                    pos = CalculatePoint(pos);
                }
                objInd = Random.Range(0, 500) % objNames.Length;
                objsInUse.Add(pool.GetObj(objNames[objInd], pos, useRotation, rot, useScale, scale));
            }

            GeneratorOff();
        }

        Vector3 CalculatePoint(Vector3 lastPoint)
        {
            Vector3 res = lastPoint;

            if (axisStep.x > 0)
            {
                res.x += Random.Range(1 - stepRandomPercent.x, 1 + stepRandomPercent.x) * axisStep.x;

                if(res.x > maxPoint.x)
                {
                    res.x = maxPoint.x;
                }
            }
            else
            {
                res.x = Random.Range(minPoint.x, maxPoint.x);
            }

            if (axisStep.y > 0)
            {
                res.y += Random.Range(1 - stepRandomPercent.y, 1 + stepRandomPercent.y) * axisStep.y;

                if (res.y > maxPoint.y)
                {
                    res.y = maxPoint.y;
                }
            }
            else
            {
                res.y = Random.Range(minPoint.y, maxPoint.y);
            }

            if (axisStep.z > 0)
            {
                res.z += Random.Range(1 - stepRandomPercent.z, 1 + stepRandomPercent.z) * axisStep.z;

                if (res.z > maxPoint.z)
                {
                    res.z = maxPoint.z;
                }
            }
            else
            {
                res.z = Random.Range(minPoint.z, maxPoint.z);
            }

            return res;
        }
    }
}
