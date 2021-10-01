using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana.MainSystems;

[System.Serializable]
public class VisualEventSettingData : DataTemplate
{
    public bool LockSystem;
    public bool UseFixedUpdate;

    public VisualEventProfile[] visualEventTemplates;

    public override void DrawTap()
    {
        throw new System.NotImplementedException();
    }
}
