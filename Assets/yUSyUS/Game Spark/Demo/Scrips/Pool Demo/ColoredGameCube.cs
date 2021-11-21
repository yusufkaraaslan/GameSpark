using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSpark;

public class ColoredGameCube : PoolObject
{
    Material material;

    public override void initilaze()
    {
        base.initilaze();

        material = GetComponent<Renderer>().material;
    }

    public override bool SpawnObj(Vector3 pos, bool useRotation, Quaternion rot, bool useScale, Vector3 scale, bool setParent = false, GameObject p = null)
    {
        bool res = base.SpawnObj(pos, useRotation, rot, useScale, scale, setParent, p);

        if (res)
        {
            material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        return res;
    }

}
