using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> CoinsChanged;

    [SerializeField] private int _targetCoins;
    [SerializeField] WinPanel _winPanel;
    [SerializeField] Timer _timer;

    public int TargetCoins => _targetCoins;

    private int _coins;

    public void AddCoins(int coins)
    {
        _coins += coins;
        if(_coins >= _targetCoins)
        {
            _winPanel.gameObject.SetActive(true);
            _timer.enabled = false;
        }

        CoinsChanged?.Invoke(_coins);
    }
}
