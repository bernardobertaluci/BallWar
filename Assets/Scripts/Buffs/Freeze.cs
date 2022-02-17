using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Freeze : Buff
{
    [SerializeField] private Shop _shop;
    [SerializeField] private TMP_Text _countBuff;
    [SerializeField] protected FreezeDebuff _freezeDebuff;

    protected int CurrentCount;
    private void OnEnable()
    {
        _freezeDebuff.EnemyFreezed += OnEnemyFreezed;
        _shop.BuffSaled += OnBuffSaled;
    }

    private void OnDisable()
    {
        _freezeDebuff.EnemyFreezed -= OnEnemyFreezed;
        _shop.BuffSaled -= OnBuffSaled;
    }
 
    private void OnEnemyFreezed()
    {
        if (CurrentCount > 0)
        {
            CurrentCount--;
            if(CurrentCount == 0)
                        _freezeDebuff.Deactivate();

            _countBuff.text = CurrentCount.ToString();
        }                 
    }

    private void OnBuffSaled()
    {
        CurrentCount++;
        _freezeDebuff.Activate();
        _countBuff.text = CurrentCount.ToString();
    }
}
