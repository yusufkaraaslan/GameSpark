using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UISettingData : DataTemplate
{
    public bool LockSystem;
    public bool ClearAllSceneOnRegister;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
