using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using SparkGameCore;
using SparkGameCore.MainSystems;

[System.Serializable]
public class SceneSetupProfile
{
    [SerializeField] public bool PoolSystem, UISystem, CameraSystem, VisualEventSystem, SoundManegerSystem, LightSystem;

}
