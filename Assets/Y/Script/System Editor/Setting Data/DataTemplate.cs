using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class DataTemplate: ScriptableObject
{
    protected SerializedObject myView;

    protected float elementSpace = 5;
    protected float sectionSpace = 20;

    public abstract void DrawTap();
}
