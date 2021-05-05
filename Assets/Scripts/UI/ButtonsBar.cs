using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBar : MonoBehaviour
{
    [SerializeField] private ElementsMenu _elementsMenu;
    private ElementData[] _elementDatas;

    public ElementData[] ElementDatas { get => _elementDatas; set => _elementDatas = value; }
    public ElementsMenu ElementsMenu { get => _elementsMenu; set => _elementsMenu = value; }

    private void Start()
    {
    }
}
