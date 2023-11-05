using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
