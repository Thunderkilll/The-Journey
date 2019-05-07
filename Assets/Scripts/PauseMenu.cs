using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    void Update()
    {

        
    }
    public void managerPauseMenu()
    {
        if (GameIsPaused)
        {
            resume();
        }
        else
        {
            pause();
        }

    }

    public void resume()
    {
        Debug.Log("resume game");
        PauseMenuUI.SetActive(false);
    }

    void pause()
    {
        Debug.Log("pause game");
        PauseMenuUI.SetActive(true);
    }
}
