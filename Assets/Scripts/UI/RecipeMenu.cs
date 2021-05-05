using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeMenu : MonoBehaviour
{
    [SerializeField] BlendSystem _blendSystem;
    [SerializeField] RecipePanel _recipePanelTemplate;
    [SerializeField] Transform _contentPanel;

    private bool _isOpened;

    private void Start()
    {
        var datas = _blendSystem.ComplexElements;

        foreach (var data in datas)
        {
            var recipePanel = Instantiate(_recipePanelTemplate, _contentPanel);
            recipePanel.Generate(data);
        }
    }

    public void Toggle()
    {
        if (_isOpened)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
        _isOpened = false;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        _isOpened = true;
    }
}
