using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using FMODUnity;

public class HackTerminalBot : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] CinemachineTargetGroup target;
    [SerializeField] GameObject hackPuzzle = null;
    [SerializeField] Hackbot hackBot;
    [SerializeField] GameObject hackingOverlayIn, hackingOverlayOut;
    [SerializeField] StudioEventEmitter playerMove;

    bool complete = false;
    bool objectiveComplete;
    PlayerMovement playerMovement;
    PlayerPower playerPower;
    GameObject puzzle = null;
    IEnumerator fade;
    bool once;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        playerPower = GameObject.FindObjectOfType<PlayerPower>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!complete && collision.gameObject.tag == "Player")
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F to hack";
        }
        else if(complete && !objectiveComplete && collision.gameObject.tag == "Player")
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F to switch control";
        }
        else
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "[I cannot use this]";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.F) && !complete && playerMovement.canControl)
        {
            playerMove.enabled = false;
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
        else if (complete && !objectiveComplete && Input.GetKey(KeyCode.F))
        {
            playerMovement.canControl = false;
            playerMovement.body.velocity = Vector2.zero;
            Send();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }

    public void Send()
    {
        fade = HackingOverlay(1);
        StartCoroutine(fade);
        for (int i = 0; i < target.m_Targets.Length; i++)
        {
            target.m_Targets[i].weight = 0;
        }
        playerMovement.canControl = false;
        playerPower.losePower = false;
        hackBot.React();
        target.m_Targets[hackBot.GetLayer()].weight = 1;
        complete = true;
        prompt.gameObject.SetActive(true);
        prompt.text = "R to return";
    }

    public void Return(bool isComplete)
    {
        once = false;
        fade = HackingOverlay(0);
        StartCoroutine(fade);
        for (int i = 0; i < target.m_Targets.Length; i++)
        {
            target.m_Targets[i].weight = 0;
        }
        if(hackBot.GetBotType() == "StrongBot")
        {
            hackBot.gameObject.GetComponent<StrongBotController>().canControl = false;
        }
        if(hackBot.GetBotType() == "CrushBot")
        {
            hackBot.gameObject.GetComponent<CrushBotController>().canControl = false;
        }

        target.m_Targets[0].weight = 1;
        objectiveComplete = isComplete;
        playerMovement.canControl = true;
        playerPower.losePower = true;
    }

    IEnumerator HackingOverlay(int type)
    {
        if (once == false)
        {
            switch (type)
            {
                case 0:
                    hackingOverlayOut.SetActive(true);
                    hackingOverlayOut.GetComponent<Animator>().SetInteger("Fade", 1);
                    break;
                case 1:
                    once = true;
                    hackingOverlayIn.SetActive(true);
                    hackingOverlayIn.GetComponent<Animator>().SetInteger("Fade", 1);
                    break;
            }
            yield return new WaitForSeconds(2f);
            hackingOverlayOut.GetComponent<Animator>().SetInteger("Fade", 0);
            hackingOverlayIn.GetComponent<Animator>().SetInteger("Fade", 0);
            switch (type)
            {
                case 0:
                    hackingOverlayOut.GetComponent<Animator>().SetInteger("Fade", -1);
                    break;
                case 1:
                    hackingOverlayIn.GetComponent<Animator>().SetInteger("Fade", -1);
                    break;
            }
            yield return new WaitForSeconds(1f);
            hackingOverlayOut.SetActive(false);
            hackingOverlayIn.SetActive(false);
            hackingOverlayOut.GetComponent<Animator>().SetInteger("Fade", 0);
            hackingOverlayIn.GetComponent<Animator>().SetInteger("Fade", 0);
        }
    }
}

