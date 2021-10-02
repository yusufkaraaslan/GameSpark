using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class DataTemplate: ScriptableObject
{
    protected SerializedObject myView;

    public static float elementSpace = 5;
    public static float sectionSpace = 20;

    public abstract void DrawTap();
}
