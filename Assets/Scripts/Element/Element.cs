using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Element : MonoBehaviour
{
    public event UnityAction<ElementData> DataChanged;

    private ElementData _data;
    private ElementCondition _condition = ElementCondition.Warm;
    private List<Element> _nerabyElements = new List<Element>();
    private List<Cristal> _nerabyCristals = new List<Cristal>();

    private BlendSystem _blendSystem;
    private Liquid _liquid;
    private ElementSensor _sensor;
    private Collider _collider;

    public ElementData Data 
    { get => _data;
        
        set 
        { 
            _data = value; 
            UpdateState();
        } 
    }

    private void Start()
    {
        _blendSystem = GetComponentInParent<BlendSystem>();
        _liquid = GetComponentInChildren<Liquid>();
        _sensor = GetComponentInChildren<ElementSensor>();
        _collider = GetComponent<Collider>();
        UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_data & _condition != ElementCondition.Spoiled)
        {
            if(other.TryGetComponent(out Element element))
            {
                if (element.Data)
                {
                    _nerabyElements.Add(element);

                    if (_nerabyElements.Count > 1)
                    {
                        Blend();
                    }
                }
            }

            if(other.TryGetComponent(out Cristal cristal))
            {
                _nerabyCristals.Add(cristal);
                SetConditionWithCristal(cristal);
            }
        }
    }

    private void SetConditionWithCristal(Cristal cristal)
    {
        if (cristal.Type == CristalType.Cold)
        {
            _condition = ElementCondition.Cold;
        }
        else if (cristal.Type == CristalType.Hot)
        {
            _condition = ElementCondition.Hot;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Element element))
        {
            _nerabyElements.Remove(element);
        }

        if (other.TryGetComponent(out Cristal cristal))
        {
            _nerabyCristals.Add(cristal);

            if(_nerabyCristals.Count == 0)
            {
                _condition = ElementCondition.Warm;
            }
        }
    }

    private void Blend()
    {
        _data = _blendSystem.Blend(_nerabyElements[0], _nerabyElements[1], _condition);
        if(_data is SpoiledElementData)
        {
            _condition = ElementCondition.Spoiled;
        }
        _nerabyElements.Clear();
        UpdateState();
    }

    public void PourOut()
    {
        _data = null;
        UpdateState();
    }

    private void UpdateState()
    {
        if (_data)
        {
            _liquid.SetColor(_data.Color);
            _liquid.gameObject.SetActive(true);
            _sensor.gameObject.SetActive(false);
            _collider.enabled = true;
        }
        else
        {
            _liquid.gameObject.SetActive(false);
            _sensor.gameObject.SetActive(true);
            _collider.enabled = false;
            _condition = ElementCondition.Warm;
        }

        DataChanged?.Invoke(_data);
    }
}

public enum ElementCondition
{
    Warm,
    Cold,
    Hot,
    Spoiled
}

