using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class CameraSettingData : DataTemplate
{
    public bool LockSystem;
    public bool SetOffCamOnRegister;

    public GameCam[] cams;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
