using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresLogic : MonoBehaviour
{
    [SerializeField] WireStart wireStart;
    [SerializeField] WireEnd[] wireEnds;
    [SerializeField] WiresReset wiresReset;
    [SerializeField] WireRandomiser wireRandomiser;

    PlayerMovement playerMovement;
    SpriteRenderer playerSprite;
    HackTerminal hackTerminal;

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
        HackTerminal[] terminals = HackTerminal.FindObjectsOfType<HackTerminal>();
        float distance = 999f;
        int index = 0;
        for(int i = 0; i < terminals.Length; i++)
        {
            if(Vector2.Distance(terminals[i].transform.position, playerMovement.gameObject.transform.position) < distance)
            {
                distance = Vector2.Distance(terminals[i].transform.position, playerMovement.gameObject.transform.position);
                index = i;
            }
        }
        hackTerminal = terminals[index];
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
            hackTerminal.Send();
            playerSprite.enabled = true;
        }
        else if(wireEnds[1].attached && wireEnds[2].attached && wireEnds[3].attached && wireEnds[0].attached && !win)
        {
            wiresReset.Reset();
            wireRandomiser.Randomise();
        }
    }
}
