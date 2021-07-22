using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject options;
    [SerializeField] GameObject controls;
    [SerializeField] MusicMenu menuMusic;

    public void Play()
    {
        SceneManager.LoadScene("Main");
        menuMusic.PlayGame();
    }

    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        controls.SetActive(false);
        main.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("The game has closed");
        Application.Quit();
    }

    public void Controls()
    {
        controls.SetActive(true);
        main.SetActive(false);
    }
}
