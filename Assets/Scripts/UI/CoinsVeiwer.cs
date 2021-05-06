using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class CoinsVeiwer : MonoBehaviour
{
    [SerializeField] private Player player;

    private TMP_Text _text;

    private void OnEnable()
    {
        player.CoinsChanged += OnCoinsChanged;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = $"0/{player.TargetCoins}";
    }

    private void OnDisable()
    {
        player.CoinsChanged -= OnCoinsChanged;
    }

    public void OnCoinsChanged(int coins)
    {
        _text.text = $"{coins}/{player.TargetCoins}"; 
    }
}
