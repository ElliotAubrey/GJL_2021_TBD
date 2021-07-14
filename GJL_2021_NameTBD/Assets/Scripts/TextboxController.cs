using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextboxController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _message;

    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            playerMovement.canControl = false;
            Time.timeScale = 0;
        }

        if (gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
            playerMovement.canControl = true;
            Time.timeScale = 1;
        }
    }

    public void CreateTextBox(string pName, string pMessage)
    {
        _name.text = pName;
        _message.text = pMessage;
        gameObject.SetActive(true);
    }
}
