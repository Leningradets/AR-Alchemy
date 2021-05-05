using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipePanel : MonoBehaviour
{
    [SerializeField] private Image _flask;
    [SerializeField] private Image _plus;
    [SerializeField] private Image _equal;
    [SerializeField] private Image _hot;
    [SerializeField] private Image _cold;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Generate(ComplexElementData data)
    {
        var recipe = data.Recipe;
        if (recipe.ElementCondition != ElementCondition.Warm)
        {
            if (recipe.ElementCondition == ElementCondition.Cold)
            {
                Instantiate(_cold, _transform);
            }
            else if (recipe.ElementCondition == ElementCondition.Hot)
            {
                Instantiate(_hot, _transform);
            }

            Instantiate(_plus, _transform);
        }

        PlaceFlask(recipe.Element1);
        Instantiate(_plus, _transform);
        PlaceFlask(recipe.Element2);
        Instantiate(_equal, _transform);
        PlaceFlask(data);
    }

    private void PlaceFlask(ElementData data)
    {
        var flask = Instantiate(_flask, _transform);
        flask.color = data.Color;
    }
}
