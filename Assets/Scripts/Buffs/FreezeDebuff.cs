using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FreezeDebuff : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event UnityAction EnemyFreezed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickFreezeButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickFreezeButton);
    }
    public void OnClickFreezeButton()
    {
        EnemyFreezed?.Invoke();
    }

    public void Deactivate()
    {
        _button.interactable = false;
    }

    public void Activate()
    {
        _button.interactable = true;
    }
}
