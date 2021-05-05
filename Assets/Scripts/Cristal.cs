using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    [SerializeField] CristalType _type;

    public CristalType Type => _type;
}

public enum CristalType
{
    Cold,
    Hot
}
