using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoverscreen : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool Unalived = false;
    public GameObject gaemoverMenuUI;
    public GameObject Player;
    public AudioSource MainTheme;
    public AudioSource GameOverTheme;
    Boolean gameoverMusic = false;
    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<ObjectCollection>().Health <= 0) 
        {
            Player.GetComponent<SimpleSampleCharacterControl>().m_moveSpeed = 0;
            Unalive();
        }
    }
    void Unalive()
    {
        MainTheme.volume = 0;
        if (gameoverMusic == false) 
        {
            GameOverTheme.Play();
            gameoverMusic = true;
        }
        
        gaemoverMenuUI.SetActive(true);
        Time.timeScale = 0.1f;
        Wait();
        Time.timeScale = 0f;
        Unalived = true;
    }
    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);

    }
}
