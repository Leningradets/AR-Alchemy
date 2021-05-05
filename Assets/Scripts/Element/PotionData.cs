using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PotionData : ComplexElementData
{
    [SerializeField] private int _cost;

    public int Cost => _cost;
}
