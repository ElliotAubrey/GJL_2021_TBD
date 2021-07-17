using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject options;
    public void Play()
    {
        SceneManager.LoadScene("Main");
    }

    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }

    public void Back()
    {
        options.SetActive(false);
        main.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("The game has closed");
        Application.Quit();
    }
}
