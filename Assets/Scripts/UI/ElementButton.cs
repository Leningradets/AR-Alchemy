using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementButton : MonoBehaviour
{
    [SerializeField] private Element _element;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _empty;
    [SerializeField] private Sprite _full;
    private ElementsMenu _menu;

    private void Start()
    {
        var bar = GetComponentInParent<ButtonsBar>();
        _menu = bar.ElementsMenu;
    }

    private void OnEnable()
    {
        _element.DataChanged += SetImageByData; 
    }

    private void OnDisable()
    {
        _element.DataChanged -= SetImageByData; 
    }

    public void SetDataToElement(ElementData data)
    {
        _element.Data = data;
    } 

    public void SetImageByData(ElementData data)
    {
        if (data)
        {
            _image.sprite = _full;
            _image.color = data.Color;
        }
        else
        {
            _image.sprite = _empty;
        }
    }

    public void OpenMenu()
    {
        _menu.Open(this);
    }
}
