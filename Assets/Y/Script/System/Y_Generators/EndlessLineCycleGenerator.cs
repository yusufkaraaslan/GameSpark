using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Y_Generators;

public class EndlessLineCycleGenerator : BaseGenerator
{
    [SerializeField]
    GameObject startPoint;
    Vector3 nextGeneratePoint;
    [SerializeField]
    Vector3 axisStep;
    [SerializeField]
    GameObject player;
    [SerializeField]
    int destroyStepBack;
    [SerializeField]
    int generateStepBefore;
    [SerializeField]
    bool gooNegativeAxis;


    public override void initilaze()
    {
        base.initilaze();
        nextGeneratePoint = startPoint.transform.position;
        //startVector = startPoint.transform.position;
    }

    public override void GeneratorOn()
    {
        nextGeneratePoint = startPoint.transform.position;
        base.GeneratorOn();

    }

    public override void Generate()
    {
        Vector3 scale = Vector3.one;
        Quaternion rot = new Quaternion();
        int objInd;

        while(ComparePoint(nextGeneratePoint, player.transform.position + generateStepBefore * axisStep) == ((gooNegativeAxis) ? 1 : -1))
        {
            objInd = Random.Range(0, 500) % objNames.Length;
            objsInUse.Add(pool.GetObj(objNames[objInd], nextGeneratePoint, useRotation, rot, useScale, scale));
            nextGeneratePoint += axisStep;
        }

        if(objsInUse.Count > 0)
        {
            if(ComparePoint(objsInUse[0].gameObject.transform.position, player.transform.position - destroyStepBack * axisStep) == ((gooNegativeAxis) ? 1 : -1))
            {
                objsInUse[0].DespawnObj();
                objsInUse.RemoveAt(0);
            }
        }
    }

    int ComparePoint(Vector3 a, Vector3 b)
    {
        Vector3 vec_A = a - startPoint.transform.position;
        Vector3 vec_B = b - startPoint.transform.position;

        Vector3 res = Vector3.zero;

        if(axisStep.x != 0)
        {
            res.x = vec_A.x - vec_B.x;
        }

        if (axisStep.y != 0)
        {
            res.y = vec_A.y - vec_B.y;
        }

        if (axisStep.z != 0)
        {
            res.z = vec_A.z - vec_B.z;
        }

        if (res.x < 0 || res.y < 0 || res.z < 0)
        {
            return -1;
        }else if (res.x > 0 || res.y > 0 || res.z > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

}
