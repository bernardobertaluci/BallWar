using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuffView : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Buff _buff;

    public event UnityAction<Buff, BuffView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Buff buff)
    {
        _buff = buff;
        _price.text = buff.Price.ToString();
        _icon.sprite = buff.Icon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_buff, this);
    }
}
