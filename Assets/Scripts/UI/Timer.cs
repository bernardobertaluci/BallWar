using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _pastTimeText;
    [SerializeField] private Player _player;

    public event UnityAction<float> TimerChanged;

    private float _startPastTime = 0;
    private float _pastTime;

    private void OnEnable()
    {
        _player.Dying += OnDying;
    }

    private void OnDisable()
    {
        _player.Dying -= OnDying;
    }
    private void Update()
    {
        ChangeScore();
    }

    private void Start()
    {
        _pastTimeText.text = _startPastTime.ToString();
    }

    public void ResetTimer()
    {
        _pastTime = 0;
        _pastTimeText.text = _startPastTime.ToString();
    }

    private void OnDying()
    {
        TimerChanged?.Invoke(_pastTime);
    }

    private void ChangeScore()
    {
        _pastTime += Time.deltaTime;
        _pastTimeText.text = _pastTime.ToString("0.00");
    }
}
