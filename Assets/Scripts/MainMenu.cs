using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text highScoreText; // Referencia al texto de la puntuación más alta en el menú de inicio

    void Start()
    {
        // Obtener y mostrar la puntuación más alta al iniciar el menú
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScoreText != null)
        {
            highScoreText.text = "000" + highScore.ToString();
        }
    }

    public void EscenaInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void EscenaNiveles()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void EscenaNvl1()
    {
        SceneManager.LoadScene("Kathe");
    }
    public void EscenaNvl2()
    {
        SceneManager.LoadScene("Santiago");
    }
    public void EscenaNvl3()
    {
        SceneManager.LoadScene("Victor");
    }
    public void EscenaNvl4()
    {
        SceneManager.LoadScene("Mateo");
    }

    public void Salir()
    {
        Application.Quit();
    }

}
