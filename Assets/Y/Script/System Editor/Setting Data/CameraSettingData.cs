using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraSettingData : DataTemplate
{
    public bool LockSystem;
    public bool SetOffCamOnRegister;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
