using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void EscenaColiseo()
    {
        SceneManager.LoadScene("Victor");
    }

    public void EscenaNiveles()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void EscenaNvl1()
    {
        SceneManager.LoadScene("Nvl1");
    }
    public void EscenaNvl2()
    {
        SceneManager.LoadScene("Nvl2");
    }
    public void EscenaNvl3()
    {
        SceneManager.LoadScene("Nvl3");
    }
    public void EscenaNvl4()
    {
        SceneManager.LoadScene("Nvl4");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
