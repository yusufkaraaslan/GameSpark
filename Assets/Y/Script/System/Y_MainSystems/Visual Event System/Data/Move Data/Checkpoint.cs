using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject tarPos;
    [SerializeField] GameObject lookPos;

    [SerializeField] GameObject[] closeObj;

    [SerializeField] string profileName;
    [SerializeField] Vector3 arc;
    [SerializeField] float rotState;
    [SerializeField] bool lockYAxis;

    [HideInInspector] public Vector3 TarPos { get => tarPos.transform.position; }
    [HideInInspector] public Vector3 LookPos { get => lookPos.transform.position; }
    [HideInInspector] public string ProfileName { get => profileName; }
    [HideInInspector] public Vector3 Arc { get => arc; }
    [HideInInspector] public float RotState { get => rotState; }
    [HideInInspector] public bool LockYAxis { get => lockYAxis; }

    private void Start()
    {
        for (int i = 0; i < closeObj.Length; i++)
        {
            closeObj[i].SetActive(false);
        }
    }



}
