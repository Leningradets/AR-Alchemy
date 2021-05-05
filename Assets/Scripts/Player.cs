using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _targetCoins;
    [SerializeField] WinPanel _winPanel;
    [SerializeField] Timer _timer;
    
    private int _coins;

    public int Coins { get => _coins; set => _coins = value; }

    public void AddCoins(int coins)
    {
        _coins += coins;
        if(_coins >= _targetCoins)
        {
            _winPanel.gameObject.SetActive(true);
            _timer.enabled = false;
        }
    }
}
