using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _money;

    private List<Buff> _buffs;
    public int Money => _money;

    public event UnityAction<int> MoneyChanged;
    public event UnityAction Dying;
    public void Die()
    {
        Dying?.Invoke();
        Destroy(gameObject);
        Time.timeScale = 0;  
    }

    public void AddMoney(int money)
    {
        _money += money;
        MoneyChanged?.Invoke(_money);
    }

    public void BuyBuff(Buff buff)
    {
        _money -= buff.Price;
        MoneyChanged?.Invoke(_money);
        _buffs.Add(buff);
    }

    
}
