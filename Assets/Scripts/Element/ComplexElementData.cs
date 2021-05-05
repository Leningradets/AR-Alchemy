using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class ComplexElementData : ElementData
{
    [SerializeField] private Recipe _recipe;

    public int Complexity => GetComplexity();

    public Recipe Recipe => _recipe;

    public bool CheckRecipe(ElementData ingredientData1, ElementData ingredientData2, ElementCondition state)
    {
        return _recipe.Check(ingredientData1, ingredientData2, state);
    }

    public override int GetComplexity()
    {
        int complexity = 1;

        complexity += Recipe.Element1.GetComplexity();
        complexity += Recipe.Element2.GetComplexity();

        return complexity;
    }
}
