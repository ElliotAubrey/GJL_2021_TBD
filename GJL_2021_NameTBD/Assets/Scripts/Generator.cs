using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] GameObject core;
    [SerializeField] bool powerOn = false;
    [SerializeField] Objective objective;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !powerOn)
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F" + "\n" + "Insert core.";
        }
        else
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "[I cannot use this]";
        }
    }

    private void Update()
    {
        switch (powerOn)
        {
            case true:
                core.SetActive(true);
                break;
            case false:
                core.SetActive(false);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.tag == "Player" && !powerOn)
        {
            powerOn = true;
            objective.NewGen();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }
}
