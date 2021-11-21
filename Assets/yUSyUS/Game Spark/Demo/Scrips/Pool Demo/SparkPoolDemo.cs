using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using GameSpark;

public class SparkPoolDemo : GameSparkDemoSceneTemplate
{
    [SerializeField] GameObject spawnPose;

    // Maneger Instance
    PoolSystem pool;
    UIManeger ui;

    private void Start()
    {
        //  Get Maneger Instance
        pool = PoolSystem.GetInstance();
        ui = UIManeger.GetInstance();
    }

    public override void StartDemo()
    {
        ui.OpenUI("PoolDemo");
    }

    public override void EndDemo()
    {
        ui.CloseUI("PoolDemo");
        pool.ClearPool();
    }

    public void GetObject(string objName)
    {
        pool.GetObj(objName, spawnPose.transform);
    }

    public void ClearObjets(string objName)
    {
        pool.ClearPool(objName);
    }

    public void ClearAll()
    {
        pool.ClearPool();
    }

}
