using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Needed namespace
using SparkGameCore.MainSystems;

public class GameManeger : MonoBehaviour
{
    DemoScene demo;
    [SerializeField]Text demoText;

    //  Maneger Instances
    UIManeger ui;

    //  Demo Scene Maneger
    [SerializeField] DemoSceneTemplate poolDemo, uiDemo, cameraDemo, visualEventDemo, soundDemo, lightDemo;

    DemoSceneTemplate activeDemo;

    private void Start()
    {
        //  Get Maneger Instance
        ui = UIManeger.GetInstance();

        ui.OpenUIClean("Menu");
        ui.OpenUI("StartButton");
    }

    public void StartDemo()
    {
        ui.OpenUIClean("InGame");

        poolDemo.StartDemo();
        activeDemo = poolDemo;
    }

    public void PreviousDemo()
    {
        if (demo == DemoScene.PoolDemo)
        {
            demo = DemoScene.LightDemo;
        }
        else
        {
            demo -= 1;
        }

        demoText.text = "" + demo;
        UpdateDemo();
    }

    public void NextDemo()
    {
        if (demo == DemoScene.LightDemo)
        {
            demo = DemoScene.PoolDemo;
        }
        else
        {
            demo += 1;
        }

        demoText.text = "" + demo;
        UpdateDemo();
    }

    private void UpdateDemo()
    {
        activeDemo.EndDemo();

        switch (demo)
        {
            case DemoScene.PoolDemo:
                poolDemo.StartDemo();
                activeDemo = poolDemo;
                break;

            case DemoScene.UIDemo:
                uiDemo.StartDemo();
                activeDemo = uiDemo;
                break;

            case DemoScene.CameraDemo:
                cameraDemo.StartDemo();
                activeDemo = cameraDemo;
                break;

            case DemoScene.VisualEventDemo:
                visualEventDemo.StartDemo();
                activeDemo = visualEventDemo;
                break;

            case DemoScene.SoundDemo:
                soundDemo.StartDemo();
                activeDemo = soundDemo;
                break;

            case DemoScene.LightDemo:
                lightDemo.StartDemo();
                activeDemo = lightDemo;
                break;
        }
    }

}

public enum DemoScene
{
    PoolDemo, UIDemo, CameraDemo, VisualEventDemo, SoundDemo, LightDemo
}