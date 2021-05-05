using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeViewer : MonoBehaviour
{
    [SerializeField] Timer _timer;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        _text.text = ((int)(_timer.SetTime - _timer.TimeFromLastReset)).ToString();
    }
}
