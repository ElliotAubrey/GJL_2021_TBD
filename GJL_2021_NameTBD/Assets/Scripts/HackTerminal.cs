using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class HackTerminal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] CinemachineTargetGroup target;
    [SerializeField] GameObject hackBot;

    bool complete = false;
    PlayerMovement player;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(true);
        prompt.text = "F";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKey(KeyCode.F) && !complete)
        {
            target.m_Targets[0].weight = 0;
            target.m_Targets[1].weight = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
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
    }
}

