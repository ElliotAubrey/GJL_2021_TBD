using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] Canvas hud;

    bool paused = false;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                pauseMenu.gameObject.SetActive(false);
                hud.gameObject.SetActive(true);
                Time.timeScale = 1;
                paused = false;
            }
            else
            {
                pauseMenu.gameObject.SetActive(true);
                hud.gameObject.SetActive(false);
                Time.timeScale = 0;
                paused = true;
            }
        }
    }
}
