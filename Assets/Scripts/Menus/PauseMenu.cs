using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    public static int inverse;
    public GameObject pauseMenuUI;
    public GameObject Player;
    void Update()
    {
        if (Player.GetComponent<ObjectCollection>().Health > 0)
        {
            if (Input.GetKeyDown("1"))
            {
                if (Paused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
           
    }
    public void inversey(bool tog)
    {
        if (tog)
        {
            inverse = 1;
        }
        else
        {
            inverse = -1;
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void MainMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
            
    }
    public void CloseGame()
    {
        Debug.Log("Bruh you quit");
        Application.Quit();
    }
}