using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
    }

    public void SetColor(Color color)
    {
        _material.color = color;
    }
}
