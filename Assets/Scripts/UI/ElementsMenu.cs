using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElementsMenu : MonoBehaviour
{
    [SerializeField] private BlendSystem _blendSystem;
    [SerializeField] private MenuButton _menuButtonTemplate;
    [SerializeField] private Transform _contentPanel;

    private ElementButton _currentElementButton;
    private ElementData[] _datas;

    public ElementButton CurrentElementButton {get => _currentElementButton; private set => _currentElementButton = value;}

    private void Awake()
    {
        _datas = _blendSystem.GetBaseElementDatas();
        GenerateButtons();
    }

    public void Open(ElementButton button)
    {
        gameObject.SetActive(true);
        _currentElementButton = button;
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void GenerateButtons()
    {
        foreach (var data in _datas)
        {
            var button = Instantiate(_menuButtonTemplate, _contentPanel);
            button.Data = data;
        }
    }
}
