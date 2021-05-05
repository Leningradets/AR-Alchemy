using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu()]
public class ElementData : ScriptableObject
{
    public Color Color;

    public virtual int GetComplexity()
    {
        return 0;
    }
}
