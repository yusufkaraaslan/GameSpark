using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject tarPos;
    [SerializeField] GameObject lookPos;

    [SerializeField] GameObject[] closeObj;

    [SerializeField] Vector3 arc;
    [SerializeField] float rotSpeed;
    [SerializeField] bool lockYAxis;

    [HideInInspector] public Vector3 TarPos { get => tarPos.transform.position; }
    [HideInInspector] public Vector3 LookPos { get => lookPos.transform.position; }
    [HideInInspector] public Vector3 Arc { get => arc; }
    [HideInInspector] public float Rotspeed { get => rotSpeed; }
    [HideInInspector] public bool LockYAxis { get => lockYAxis; }

    private void Start()
    {
        for (int i = 0; i < closeObj.Length; i++)
        {
            closeObj[i].SetActive(false);
        }
    }
}
