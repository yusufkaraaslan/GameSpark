using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Yatana;

public class SceneSetupProfile
{
    public Dictionary<string, bool> modules = new Dictionary<string, bool>();

    public bool[] currBools;

    public void UpdateSystems(List<string> newModuls)
    {
        Dictionary<string, bool> tmp = new Dictionary<string, bool>();
        currBools = new bool[newModuls.Count]; 

        foreach (string item in newModuls)
        {
            tmp.Add(item, (modules.ContainsKey(item)) ? modules[item] : false);
        }
        
        for (int i = 0; i < newModuls.Count; i++)
        {
            if (modules.ContainsKey(newModuls[i]))
            {
                currBools[i] = modules[newModuls[i]];
            }
        }

        modules = tmp;
    }
}
