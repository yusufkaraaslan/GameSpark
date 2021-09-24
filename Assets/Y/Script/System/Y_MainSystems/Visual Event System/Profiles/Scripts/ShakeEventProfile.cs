using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shake Event Profile", menuName = "Shake Event Profile", order = 51)]
public class ShakeEventProfile : ScriptableObject
{
    public string eventName;

    public float duration;
    public float speed;
    public float magnitude;
    public float rotationDamper;
}
