using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menupausa : MonoBehaviour
{
    public bool ispaused;
    public GameObject menudepausa;

    void Start()
    {
        menudepausa.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            if (ispaused)
            {
                Resumegame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        menudepausa.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void Resumegame()
    {
        menudepausa.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }

    public void Gotomainmenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuprincipal");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
