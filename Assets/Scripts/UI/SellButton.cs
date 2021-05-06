using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SellButton : MonoBehaviour
{
    public event UnityAction<int> PotionSold;

    [SerializeField] private BlendSystem _blendSystem;
    [SerializeField] private Image _image;

    private PotionData _data;

    public PotionData Data
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

    public void TrySellPotion()
    {
        var elements = _blendSystem.GetComponentsInChildren<Element>();

        foreach (var element in elements)
        {
            if (element.Data == _data)
            {
                PotionSold?.Invoke(_data.Cost);
                element.Data = null;
            }
        }
    }

}
