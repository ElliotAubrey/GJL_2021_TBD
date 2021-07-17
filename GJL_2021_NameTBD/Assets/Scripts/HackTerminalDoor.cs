using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class HackTerminalDoor : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] GameObject hackPuzzle = null;
    [SerializeField] Door[] doors;

    bool complete = false;
    PlayerMovement playerMovement;
    PlayerPower playerPower;
    GameObject puzzle = null;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerPower = GameObject.FindObjectOfType<PlayerPower>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!complete && collision.gameObject.tag == "Player")
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F to hack";
        }
        else
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "[I cannot use this]";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && !complete)
        {
            if (puzzle == null)
            {
                GameObject x = Instantiate(hackPuzzle.gameObject);
                puzzle = x;
                puzzle.transform.position = playerMovement.transform.position;
            }
            playerMovement.canControl = false;
            playerPower.losePower = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            prompt.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }

    public void Send()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Open();
        }
        playerMovement.canControl = true;
    }

    public void Return()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
        complete = true;
        playerMovement.canControl = true;
        playerPower.losePower = true;
    }
}

