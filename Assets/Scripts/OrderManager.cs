using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{ 
    [SerializeField] private BlendSystem _blendSystem;
    [SerializeField] private Player _player;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameOverPanel _losePanel;
    [SerializeField] private int _timerFactor;
    [SerializeField] private SellButton _sellButton;

    private PotionData[] _potionDatas;
    private PotionData _currentOrder;

    public PotionData CurrentOrder => _currentOrder;

    private void OnEnable()
    {
        _timer.TimeIsUp += OnTimeIsUp;
        _sellButton.PotionSold += OnPotionSold;
    }

    private void Start()
    {
        _potionDatas = _blendSystem.GetPotionDatas();
        SetOrder();
    }

    private void SetOrder()
    {
        _currentOrder = _potionDatas[Random.Range(0, _potionDatas.Length)];
        _sellButton.Data = _currentOrder;
        _timer.Set(_currentOrder.Complexity * _timerFactor);
    }

    private void OnDisable()
    {
        _timer.TimeIsUp -= OnTimeIsUp;
        _sellButton.PotionSold -= OnPotionSold;
    }

    public void OnTimeIsUp()
    {
        _losePanel.gameObject.SetActive(true);
        _timer.enabled = false;
    }

    public void OnPotionSold(int potionCost)
    {
        SetOrder();
    }
}
