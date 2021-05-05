using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendSystem : MonoBehaviour
{
    [SerializeField] private ComplexElementData[] _complexElements;
    [SerializeField] private PotionData[] _potions;
    [SerializeField] private SpoiledElementData _spoiledElement;

    public ComplexElementData[] ComplexElements => _complexElements; 
    public PotionData[] Potions => _potions;

    public ElementData Blend(Element element1, Element element2, ElementCondition state)
    {
        var elementData1 = element1.Data;
        var elementData2 = element2.Data; 

        if(elementData1 == elementData2)
        {
            return elementData1;
        }

        foreach (var complexElement in _complexElements)
        {
            if(complexElement.CheckRecipe(elementData1, elementData2, state))
            {
                return complexElement;
            }
        }

        return _spoiledElement;
    }

    public ElementData[] GetBaseElementDatas()
    {
        List<ElementData> baseElements = new List<ElementData>();

        foreach (var complexElement in _complexElements)
        {
            var recipe = complexElement.Recipe;
            var element1 = recipe.Element1;
            var element2 = recipe.Element2;

            TryAddBaseElement(baseElements, element1);
            TryAddBaseElement(baseElements, element2);
        }

        return baseElements.ToArray();
    }

    public PotionData[] GetPotionDatas()
    {
        List<PotionData> potionDatas = new List<PotionData>();

        foreach (var complexElement in _complexElements)
        {
            if(complexElement is PotionData)
            {
                potionDatas.Add(complexElement as PotionData);
            }
        }

        return potionDatas.ToArray();
    }

    private static void TryAddBaseElement(List<ElementData> ElementsArray, ElementData elementData)
    {
        if (!(elementData is ComplexElementData) & !ElementsArray.Contains(elementData))
        {
            ElementsArray.Add(elementData);
        }
    }
}
