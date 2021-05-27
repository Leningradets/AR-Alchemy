using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSpawner : MonoBehaviour
{
    [SerializeField] private SteamFX _steamFX;

    private Element _element;

    private void Awake()
    {
        _element = GetComponentInParent<Element>();   
    }

    private void OnEnable()
    {
        _element.DataChanged += Spawn;
    }

    private void OnDisable()
    {
        _element.DataChanged -= Spawn;
    }

    public void Spawn(ElementData data)
    {
        Instantiate(_steamFX, transform.position, Quaternion.identity, transform);
    }
}
