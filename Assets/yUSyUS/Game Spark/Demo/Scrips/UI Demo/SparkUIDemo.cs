using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Needed namespace
using GameSpark;

public class SparkUIDemo : GameSparkDemoSceneTemplate
{
    //  Pool Maneger Instance
    UIManeger ui;

    private void Start()
    {
        //  Get Maneger Instance
        ui = UIManeger.GetInstance();
    }

    public override void StartDemo()
    {
        ui.OpenUI("UIDemo");
    }

    public override void EndDemo()
    {
        ui.OpenUIClean("InGame");
    }

    public void OpenPanel(string panelName)
    {
        ui.OpenUI(panelName);
    }

    public void ClosePanel(string panelName)
    {
        ui.CloseUI(panelName);
    }

    public void OpenPanelClean(string panelName)
    {
        ui.OpenUIClean(panelName);

        ui.OpenUI("InGame");
        ui.OpenUI("UIDemo");
    }

    public void ClearScreen()
    {
        ui.ClearScreen();

        ui.OpenUI("InGame");
        ui.OpenUI("UIDemo");
    }
}
