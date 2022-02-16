using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Timer _score;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        if(_player.IsAlive == false)
        {
            _enemy.ResetEnemy();
            _player.ResetPlayer();
            _score.ResetTimer();
        }
    } 

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart(GameObject panel)
    {
        panel.SetActive(false);
        _enemy.ResetEnemy();
        _player.ResetPlayer();
        _score.ResetTimer();
        Time.timeScale = 1;
    }
}
