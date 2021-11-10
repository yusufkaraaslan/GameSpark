using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Needed namespace
using SparkGameCore;

public class SparkLightDemo : SparkCoreDemoSceneTemplate
{
    [SerializeField] Slider intensity, range;
    [SerializeField] GameObject sceneRoot;
    [SerializeField] GameObject focusObj;

    // Maneger Instance
    LightManeger lightManeger;
    UIManeger ui;

    private void Start()
    {
        //  Get Maneger Instance
        lightManeger = LightManeger.GetInstance();
        ui = UIManeger.GetInstance();

        lightManeger.GetLight("Spotlight").LightOff();
    }

    public override void StartDemo()
    {
        sceneRoot.SetActive(true);
        ui.OpenUI("LightDemo");
    }

    public override void EndDemo()
    {
        sceneRoot.SetActive(false);

        //  Reset All Light
        lightManeger.GetLight("Sun").LightOn();
        lightManeger.GetLight("Sun").SetIntensity(1);
        lightManeger.GetLight("Spotlight").LightOff();

        ui.CloseUI("LightDemo");
    }

    public void LightOn(string lightName)
    {
        lightManeger.GetLight(lightName).LightOn();
    }

    public void LightOff(string lightName)
    {
        lightManeger.GetLight(lightName).LightOff();
    }

    public void RedSpotlight()
    {
        SetLight("Spotlight", Color.red);
    }
    public void BlueSpotlight()
    {
        SetLight("Spotlight", Color.blue);
    }

    public void SetLightPower()
    {
        lightManeger.GetLight("Sun").SetIntensity(intensity.value);
        lightManeger.GetLight("Spotlight").SetRange(range.value);
    }

    public void FocusLight(string lightName)
    {
        lightManeger.GetLight(lightName).SetAngle(focusObj);
    }

    public void UnfocusLight(string lightName)
    {
        lightManeger.GetLight(lightName).SetAngle(Quaternion.Euler(90, 0, 0));
    }

    void SetLight(string lightName, Color color)
    {
        lightManeger.GetLight(lightName).SetColor(color);
    }

}
