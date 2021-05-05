using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public event UnityAction TimeIsUp;

    private float _setTime;
    private float _timeFromLastReset;

    public float SetTime => _setTime;
    public float TimeFromLastReset => _timeFromLastReset;

    private void Update()
    {
        _timeFromLastReset += Time.deltaTime;

        if(_timeFromLastReset > _setTime)
        {
            TimeIsUp?.Invoke();
        }
    }

    public void Set(float time)
    {
        _setTime = time;
        Reset();
    }

    private void Reset()
    {
        _timeFromLastReset = 0;
    }
}
