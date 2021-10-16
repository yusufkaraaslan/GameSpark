using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    Material material;


    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void ChangeColor()
    {
        material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        Debug.Log("Done...");
    }
}
