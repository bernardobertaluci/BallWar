using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private Score _score;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    } 

    public void Exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _enemy.ResetEnemy();
        Time.timeScale = 1;
        _enemy.Mover();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        _enemy.ResetEnemy();
        _enemy.Mover();
    }
}
