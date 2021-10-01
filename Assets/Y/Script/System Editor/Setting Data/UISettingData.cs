using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class UISettingData : DataTemplate
{
    public bool LockSystem;
    public bool ClearAllSceneOnRegister;

    public UISetup[] setups;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
