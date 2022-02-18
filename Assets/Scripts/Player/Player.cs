using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;
    [SerializeField] private Timer _timer;

    private int _money;

    public int Money => _money;

    public bool IsAlive { get; private set; }

    public event UnityAction<int> MoneyChanged;
    public event UnityAction Dying;

    private void OnEnable()
    {
        _timer.TimerChanged += OnTimerChanged;
    }

    private void OnDisable()
    {
        _timer.TimerChanged -= OnTimerChanged;
    }
    private void Start()
    {
        IsAlive = true;
        transform.position = _startPosition;
    }
    public void Die()
    {
        IsAlive = false;
        Dying?.Invoke(); 
    }

    public void BuyBuff(Buff buff)
    {
        _money -= buff.Price;
        MoneyChanged?.Invoke(_money);
    }

    public void ResetPlayer()
    {
        IsAlive = true;
        transform.position = _startPosition;
    }

    private void OnTimerChanged(float time)
    {
        _money += (int)time;
        MoneyChanged?.Invoke(_money);
    }
}
