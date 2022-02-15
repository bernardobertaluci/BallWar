using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Buff> _buffs;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private BuffView _template;

    private void Start()
    {
        for (int i = 0; i < _buffs.Count; i++)
        {
            AddItem(_buffs[i]);
        }
    }

    private void AddItem(Buff buff)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(buff);
    }

    private void OnSellButtonClick(Buff buff, BuffView buffView)
    {
        TrySellBuff(buff, buffView);
    }

    private void TrySellBuff(Buff buff, BuffView buffView)
    {
        if(buff.Price <= _player.Money)
        {
            _player.BuyBuff(buff);
            buff.Buy();
            buffView.SellButtonClick -= OnSellButtonClick;
        }
    }
}
