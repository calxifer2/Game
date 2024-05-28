using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EscenaInicio()
    {
        SceneManager.LoadScene("Inicio");
    }

    public void Salir()
    {
        Application.Quit();
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


}
