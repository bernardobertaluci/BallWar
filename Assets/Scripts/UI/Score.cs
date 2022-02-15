using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private Player _player;

    private int _score;
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
    private void ChangeScore()
    {
        _pastTime += Time.deltaTime;
        _scoreText.text = _pastTime.ToString("0.00");
    }

    public void SaveScore()
    {
        if(float.TryParse(_scoreText.text, out float score))
        {
            _score = (int)score;
        }
    }
    private void OnDying()
    {
        SaveScore();
        _player.AddMoney(_score);
    }
}
