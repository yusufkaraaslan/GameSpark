using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class PoolSettingData : DataTemplate
{
    public bool IsOn = false;

    public bool LockSystem;
    public bool CloseObjectOnDespawn;

    public PoolObj[] poolObjects;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
