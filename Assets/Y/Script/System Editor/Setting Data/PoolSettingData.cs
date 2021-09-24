using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolSettingData : DataTemplate
{
    public bool LockSystem;
    public bool CloseObjectOnDespawn;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
