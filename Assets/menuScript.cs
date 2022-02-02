using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
 

    public void StartJoc()
    {
        SceneManager.LoadScene("play");

    }
    public void Iesire()
    {
        Application.Quit();
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
