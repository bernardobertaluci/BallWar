using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    //[SerializeField] private Earth _player;


    private void Update()
    {
        ScoreChanging();
    }
    private void ScoreChanging()
    {
        _score.text = Time.time.ToString("0.00");
    }
}
