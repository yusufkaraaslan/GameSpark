using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Needed namespace
using GameSpark;

public class GameSparkDemo : MonoBehaviour
{
    SparkCoreDemoScene demo;
    [SerializeField]Text demoText;

    //  Maneger Instances
    UIManeger ui;

    //  Demo Scene Maneger
    [SerializeField] GameSparkDemoSceneTemplate poolDemo, uiDemo, cameraDemo, visualEventDemo, soundDemo, lightDemo;

    GameSparkDemoSceneTemplate activeDemo;

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
        if (demo == SparkCoreDemoScene.PoolDemo)
        {
            demo = SparkCoreDemoScene.LightDemo;
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
        if (demo == SparkCoreDemoScene.LightDemo)
        {
            demo = SparkCoreDemoScene.PoolDemo;
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
            case SparkCoreDemoScene.PoolDemo:
                poolDemo.StartDemo();
                activeDemo = poolDemo;
                break;

            case SparkCoreDemoScene.UIDemo:
                uiDemo.StartDemo();
                activeDemo = uiDemo;
                break;

            case SparkCoreDemoScene.CameraDemo:
                cameraDemo.StartDemo();
                activeDemo = cameraDemo;
                break;

            case SparkCoreDemoScene.VisualEventDemo:
                visualEventDemo.StartDemo();
                activeDemo = visualEventDemo;
                break;

            case SparkCoreDemoScene.SoundDemo:
                soundDemo.StartDemo();
                activeDemo = soundDemo;
                break;

            case SparkCoreDemoScene.LightDemo:
                lightDemo.StartDemo();
                activeDemo = lightDemo;
                break;
        }
    }

}

public enum SparkCoreDemoScene
{
    PoolDemo, UIDemo, CameraDemo, VisualEventDemo, SoundDemo, LightDemo
}