using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkColorChanger : MonoBehaviour
{
    Material material;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public bool ChangeColor()
    {
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return true;
    }
}
