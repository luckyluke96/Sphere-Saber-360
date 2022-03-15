using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasScript : MonoBehaviour
{
    public void StartLevelCircular()
    {
        SceneManager.LoadScene(1);
    }

    public void StartLevelRandom()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
