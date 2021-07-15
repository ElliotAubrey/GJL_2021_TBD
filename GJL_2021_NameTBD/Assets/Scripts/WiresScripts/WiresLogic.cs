using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresLogic : MonoBehaviour
{
    [SerializeField] WireStart wireStart;
    [SerializeField] WireEnd[] wireEnds;
    [SerializeField] WiresReset wiresReset;
    [SerializeField] WireRandomiser wireRandomiser;
    [SerializeField] bool isDoor = false;

    PlayerMovement playerMovement;
    SpriteRenderer playerSprite;
    HackTerminalBot hackTerminal;
    HackTerminalDoor hackTerminalDoor;

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;
    bool win = false;


    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerSprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        //find the closest hack terminal
        HackTerminalDoor[] terminalDoors = FindObjectsOfType<HackTerminalDoor>();
        HackTerminalBot[] terminals = HackTerminalBot.FindObjectsOfType<HackTerminalBot>();
        float distance = 999f;
        int index = 0;
        if(!isDoor)
        {
            for (int i = 0; i < terminals.Length; i++)
            {
                if (Vector2.Distance(terminals[i].transform.position, playerMovement.gameObject.transform.position) < distance)
                {
                    distance = Vector2.Distance(terminals[i].transform.position, playerMovement.gameObject.transform.position);
                    index = i;
                }
            }
            hackTerminal = terminals[index];
        }
        else
        {
            for (int i = 0; i < terminalDoors.Length; i++)
            {
                if (Vector2.Distance(terminalDoors[i].transform.position, playerMovement.gameObject.transform.position) < distance)
                {
                    distance = Vector2.Distance(terminalDoors[i].transform.position, playerMovement.gameObject.transform.position);
                    index = i;
                }
            }
            hackTerminalDoor = terminalDoors[index];
        }
       
    }
    void Update()
    {
        b1 = wireEnds[0].correct;
        b2 = wireEnds[1].correct;
        b3 = wireEnds[2].correct;
        b4 = wireEnds[3].correct;

        if(b1 && b2 && b3 && b4)
        {
            wiresReset.Win();
            win = true;
            playerMovement.canControl = true;
            if(!isDoor)
            {
                hackTerminal.Send();
            }
            else
            {
                hackTerminalDoor.Send();
            }
            playerSprite.enabled = true;
        }
        else if(wireEnds[1].attached && wireEnds[2].attached && wireEnds[3].attached && wireEnds[0].attached && !win)
        {
            wiresReset.Reset();
            wireRandomiser.Randomise();
        }
    }
}
