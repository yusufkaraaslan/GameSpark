using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using SparkGameCore.MainSystems;

public class CameraDemo : DemoSceneTemplate
{
    //  Pool Maneger Instance
    CamSystem camSystem;
    UIManeger ui;

    [SerializeField] ImmediateCamLayout defult, pose1, pose2;
    [SerializeField] BasicFollowCamLayout followPose;

    [SerializeField] GameObject sceneRoot, cubeTrain;

    private void Start()
    {
        cubeTrain.SetActive(false);

        //  Get Maneger Instance
        camSystem = CamSystem.GetInstance();
        ui = UIManeger.GetInstance();
    }

    public override void StartDemo()
    {
        ui.OpenUI("CamDemo");
        cubeTrain.SetActive(true);
        sceneRoot.SetActive(true);
    }

    public override void EndDemo()
    {
        ui.CloseUI("CamDemo");
        cubeTrain.SetActive(false);

        camSystem.SetCam("Main", new ImmediateCam(), defult);
    }

    public void SetPose(string pose)
    {
        switch (pose)
        {
            case "Defult":
                camSystem.SetCam("Main", new ImmediateCam(), defult);
                break;

            case "Pose1":
                camSystem.SetCam("Main", new ImmediateCam(), pose1);
                break;

            case "Pose2":
                camSystem.SetCam("Main", new ImmediateCam(), pose2);
                break;

            case "FollowPose":
                camSystem.SetCam("Main", new BasicFollowCam(), followPose);
                break;
        }
    }


}
