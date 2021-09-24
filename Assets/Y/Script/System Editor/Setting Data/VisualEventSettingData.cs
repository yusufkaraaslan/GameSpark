using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisualEventSettingData : DataTemplate
{
    public bool LockSystem;
    public bool UseFixedUpdate;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
