using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class HackTerminal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] CinemachineTargetGroup target;
    [SerializeField] GameObject hackPuzzle = null;
    [SerializeField] Hackbot hackBot;

    SpriteRenderer playerSprite;
    bool complete = false;
    PlayerMovement playerMovement;
    PlayerPower playerPower;
    GameObject puzzle = null;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerPower = GameObject.FindObjectOfType<PlayerPower>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!complete)
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.F) && !complete)
        {
            if(puzzle == null)
            {
                GameObject x = Instantiate(hackPuzzle.gameObject);
                puzzle = x;
                puzzle.transform.position = playerMovement.transform.position;
                playerSprite.enabled = false;
            }
            playerMovement.canControl = false;
            playerPower.losePower = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }

    public void Send()
    {
        for (int i = 0; i < target.m_Targets.Length; i++)
        {
            target.m_Targets[i].weight = 0;
        }
        playerMovement.canControl = false;
        playerPower.losePower = false;
        hackBot.React();
        target.m_Targets[hackBot.GetLayer()].weight = 1;
        prompt.gameObject.SetActive(false);
    }

    public void Return()
    {
        for (int i = 0; i < target.m_Targets.Length; i++)
        {
            target.m_Targets[i].weight = 0;
        }
        target.m_Targets[0].weight = 1;
        complete = true;
        playerMovement.canControl = true;
        playerPower.losePower = true;
    }
}

