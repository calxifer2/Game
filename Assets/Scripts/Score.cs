using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    public static Score instance; // Singleton instance

    public int score = 0; // Puntuaci�n del jugador
    public Text scoreText; // Texto de la puntuaci�n en el UI
    public int highScore;

    void Awake()
    {
        // Establecer el singleton instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Recuperar la puntuaci�n m�s alta almacenada
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        // Actualizar el texto de la puntuaci�n al inicio
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "000" + score.ToString();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

}
