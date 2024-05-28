using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    
    public static Score instance; // Singleton instance

    public int score = 0; // Puntuación del jugador
    public Text scoreText; // Texto de la puntuación en el UI
    public int targetNvl1 = 500; // Nivel 1
    public int targetNvl2 = 1000; // Nivel 2
    public int targetNvl3 = 1500; // Nivel 5
    public int targetNvl4 = 2000; // Nivel 4
    public string nextNvl2 = "Santiago";
    public string nextNvl3 = "Victor";
    public string nextNvl4 = "Mateo";
    public string nextNvl5 = "Endless";

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
        // Recuperar la puntuación más alta almacenada
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        CheckScore();
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

    void CheckScore()
    {
        if (score >= targetNvl1 && score <= targetNvl2)
        {
            LoadNvl2();
        }
        else if(score >= targetNvl2  && score <= targetNvl3)
        {
            LoadNvl3();
        }
        else if (score >= targetNvl3 && score <= targetNvl4)
        {
            LoadNvl4();
        }
        else
        {
            LoadNvl5();
        }
    }

    /*--- 2 ---*/
    void LoadNvl2()
    {
        SceneManager.LoadScene(nextNvl2);
    }

    /*--- 3 ---*/
    void LoadNvl3()
    {
        SceneManager.LoadScene(nextNvl3);
    }

    /*--- 4 ---*/
    void LoadNvl4()
    {
        SceneManager.LoadScene(nextNvl4);
    }

    /*--- 5 ---*/
    void LoadNvl5()
    {
        SceneManager.LoadScene(nextNvl5);
    }

}
