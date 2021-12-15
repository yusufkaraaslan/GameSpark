using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using GameSpark;

public class CameraDemo : GameSparkDemoSceneTemplate
{
    //  Pool Maneger Instance
    CameraSystem camSystem;
    UIManager ui;

    [SerializeField] FixedCamLayout defult, pose1, pose2;
    [SerializeField] BasicFollowCamLayout followPose;

    [SerializeField] GameObject sceneRoot, cubeTrain;

    private void Start()
    {
        cubeTrain.SetActive(false);

        //  Get Maneger Instance
        camSystem = CameraSystem.GetInstance();
        ui = UIManager.GetInstance();
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

        camSystem.SetCam("Main", defult);
    }

    public void SetPose(string pose)
    {
        switch (pose)
        {
            case "Defult":
                camSystem.SetCam("Main", defult);
                break;

            case "Pose1":
                camSystem.SetCam("Main", pose1);
                break;

            case "Pose2":
                camSystem.SetCam("Main", pose2);
                break;

            case "FollowPose":
                camSystem.SetCam("Main", followPose);
                break;
        }
    }


}
