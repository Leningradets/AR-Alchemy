using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Image _image;
    private ElementsMenu _menu;
    private Button _button;
    private ElementData _data;

    private event UnityAction Clicked;

    private void Awake()
    {
        _menu = GetComponentInParent<ElementsMenu>();
        _button = GetComponent<Button>();
        Clicked += OnClicked;

        _button.onClick.AddListener(Clicked);
    }

    public ElementData Data 
    { 
        get => _data;

        set 
        { 
            _data = value;
            if (_data)
            {
                _image.color = _data.Color;
            }
        }
    }

    private void OnClicked()
    {
        var currentElementButton = _menu.CurrentElementButton;
        currentElementButton.SetDataToElement(_data);
        _menu.Close();
    }
}
