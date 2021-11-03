using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using SparkGameCore.MainSystems;

public class VisualDemo : SparkCoreDemoSceneTemplate
{
    //  Pool Maneger Instance
    UIManeger ui;
    VisualEventController visualEvent;

    [SerializeField] GameObject sceneRoot;
    [SerializeField] Checkpoint target1, target2, target3;
    [SerializeField] GameCharacter agentC, enemy;
    
    [SerializeField] BasicFollowCamLayout followCam;
    [SerializeField] ImmediateCamLayout defultPose;

    [SerializeField] ColorChanger endWall;

    private void Start()
    {
        //  Get Maneger Instance
        ui = UIManeger.GetInstance();
        visualEvent = VisualEventController.GetInstance();

        sceneRoot.SetActive(false);
    }

    public override void StartDemo()
    {
        ui.OpenUI("VisualEventDemo");

        agentC.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);

        sceneRoot.SetActive(true);
    }

    public override void EndDemo()
    {
        ui.CloseUI("VisualEventDemo");
        sceneRoot.SetActive(false);

        ResetSetup();

        agentC.gameObject.SetActive(false);
        enemy.gameObject.SetActive(false);
    }

    public void StartEvent1()
    {
        ResetSetup();
        StopAllEvent();

        VisualEventData eventData = visualEvent.GetVisualEventData("Event 1");

        eventData.GetMove().moveOrders[0].obj = agentC.gameObject;
        eventData.GetMove().moveOrders[0].AddCheckPoint(target1);
        eventData.GetMove().moveOrders[0].AddCheckPoint(target2);
        eventData.GetMove().moveOrders[0].AddCheckPoint(target3);

        visualEvent.AddVisualEvent(eventData);
    }

    public void StartEvent2()
    {
        ResetSetup();
        StopAllEvent();

        VisualEventData eventData = visualEvent.GetVisualEventData("Event 2");

        eventData.GetMove().moveOrders[0].obj = agentC.gameObject;
        eventData.GetMove().moveOrders[0].AddCheckPoint(target1);
        eventData.GetMove().moveOrders[0].AddCheckPoint(target2);

        eventData.GetMove().moveOrders[1].obj = agentC.gameObject;
        eventData.GetMove().moveOrders[1].AddCheckPoint(target3);

        eventData.GetAnim().animOrders[0].anim = agentC.GetAnimator();
        eventData.GetAnim().animOrders[2].anim = agentC.GetAnimator();

        eventData.GetAnim().animOrders[1].anim = enemy.GetAnimator();

        visualEvent.AddVisualEvent(eventData);
    }

    public void StartEvent3()
    {
        ResetSetup();
        StopAllEvent();

        VisualEventData eventData = visualEvent.GetVisualEventData("Event 3");

        eventData.GetMove().moveOrders[0].obj = agentC.gameObject;
        eventData.GetMove().moveOrders[0].AddCheckPoint(target1);
        eventData.GetMove().moveOrders[0].AddCheckPoint(target2);

        eventData.GetMove().moveOrders[1].obj = agentC.gameObject;
        eventData.GetMove().moveOrders[1].AddCheckPoint(target3);

        eventData.GetAnim().animOrders[0].anim = agentC.GetAnimator();
        eventData.GetAnim().animOrders[2].anim = agentC.GetAnimator();

        eventData.GetAnim().animOrders[1].anim = enemy.GetAnimator();

        eventData.GetFunctions().functions[0].worker = new BasicFunction(SetFollowCam);
        eventData.GetFunctions().functions[1].worker = new BasicFunction(endWall.ChangeColor);

        visualEvent.AddVisualEvent(eventData);
    }

    public void StopAllEvent()
    {
        visualEvent.ClearAllEvents();
    }

    void SetFollowCam()
    {
        CamSystem.GetInstance().SetCam("Main", new BasicFollowCam(), followCam);
    }

    void ResetSetup()
    {
        CamSystem.GetInstance().SetCam("Main", new ImmediateCam(), defultPose);

        agentC.ResetCheracter();
        enemy.ResetCheracter();
    }
}
