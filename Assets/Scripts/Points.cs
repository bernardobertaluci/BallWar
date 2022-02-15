using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Points : MonoBehaviour
{
    public Text scoreText;


    // приватное поле и свойство к нему
    private int _scoreValue;
    public int Score
    {
        get => _scoreValue;
        set
        {
            _scoreValue = value;
            updateScoreUIText();  // обновляем текстовое поле
        }
    }


    // обновление текстового поля в игре
    private void updateScoreUIText()
    {
        scoreText.text = Score.ToString();
    }

    public void addClick()
    {
        Score += 100;
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("sv"))
        {
            Save sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("sv"));
            Score = sv.score;
        }
    }

    private void OnApplicationQuit()
    {
        Save sv = new Save();
        sv.score = Score;
        PlayerPrefs.SetString("sv", JsonUtility.ToJson(sv));
    }

}

[Serializable]
public class Save
{
    public int score;
}