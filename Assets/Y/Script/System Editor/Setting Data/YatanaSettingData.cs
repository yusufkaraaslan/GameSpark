using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yatana;
using MainSystems;
using UnityEditor;

[System.Serializable]
public class YatanaSettingData : DataTemplate
{
    static string[] MainModules =
        {
        "Yatana.MainSystems.PoolSystem",
        "Yatana.MainSystems.UIManeger",
        "Yatana.MainSystems.CamSystem",
        "Yatana.MainSystems.VisualEventController",
        "Yatana.MainSystems.SoundManeger" };

    [SerializeField] public List<string> modules = new List<string>(MainModules);

    SerializedProperty soModules;

    public override void DrawTap()
    {
        myView = new SerializedObject(this);
        soModules = myView.FindProperty("modules");

        EditorGUILayout.PropertyField(soModules);
        GUILayout.Space(elementSpace);
    }

    public void ResetModules()
    {
        modules.Clear();

        foreach (string module in MainModules)
        {
            modules.Add(module);
        }
    }

}
