using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Recipe
{
    [SerializeField] private ElementData _element1;
    [SerializeField] private ElementData _element2;
    [SerializeField] private ElementCondition _elementCondition;

    public ElementData Element1 => _element1;
    public ElementData Element2 => _element2;
    public ElementCondition ElementCondition => _elementCondition;

    public bool Check(ElementData element1, ElementData element2, ElementCondition elementCondition)
    {
        if (CheckElements(element1, element2) & CheckCondition(elementCondition))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckElements(ElementData element1, ElementData element2)
    {
        return (element1 == _element1 & element2 == _element2 || element1 == _element2 & element2 == _element1);
    }

    private bool CheckCondition(ElementCondition elementCondition)
    {
        return elementCondition == _elementCondition;
    }
}
