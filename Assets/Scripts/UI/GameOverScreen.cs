using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    private Menu _menu;

    public event UnityAction RestartButtonClick;
    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _button.interactable = false;
        _menu.Restart();
    }

    public void Open()
    {
        _canvasGroup.alpha = 1;
        _button.interactable = true;
    }

    public void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
