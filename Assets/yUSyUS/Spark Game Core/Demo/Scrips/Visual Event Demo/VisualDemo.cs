using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using SparkGameCore.MainSystems;

public class VisualDemo : DemoSceneTemplate
{
    //  Pool Maneger Instance
    UIManeger ui;
    VisualEventController visualEvent;

    [SerializeField] GameObject agentC;
    Vector3 agentCRespartPos;
    Quaternion agentCResetRot;

    //  Test Scenes 1
    [SerializeField] GameObject sceneRoot;
    [SerializeField] Checkpoint target1;



    private void Start()
    {
        //  Get Maneger Instance
        ui = UIManeger.GetInstance();
        visualEvent = VisualEventController.GetInstance();

        agentCRespartPos = agentC.transform.position;
        agentCResetRot = agentC.transform.rotation;

        agentC.SetActive(false);
    }

    public override void StartDemo()
    {
        ui.OpenUI("VisualEventDemo");

        agentC.SetActive(true);
    }

    public override void EndDemo()
    {
        ui.CloseUI("VisualEventDemo");

        agentC.SetActive(false);
    }

    public void StartEvent1()
    {
        ResetAgent();
        StopAllEvent();
        sceneRoot.SetActive(true);

        VisualEventData eventData = visualEvent.GetVisualEventData("Event 1");

        eventData.GetMove().moveOrders[0].obj = agentC;
        eventData.GetMove().moveOrders[0].AddCheckPoint(target1);

        visualEvent.AddVisualEvent(eventData);
    }

    public void StopAllEvent()
    {
        visualEvent.ClearAllEvents();
    }

    void ResetAgent()
    {
        agentC.transform.position = agentCRespartPos;
        agentC.transform.rotation = agentCResetRot;
    }
}
