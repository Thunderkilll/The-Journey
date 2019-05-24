using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    private Scene scene;
    void Start()
    {
        scene = SceneManager.GetActiveScene();
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

   public void pause()
    {
        Debug.Log("pause game");
        PauseMenuUI.SetActive(true);
    }
    public void restart()
    {
        Debug.Log("restart game");
        Application.LoadLevel(scene.name);
    }
}
