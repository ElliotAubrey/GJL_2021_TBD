using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] GameObject core;
    [SerializeField] bool powerOn;

    void Start()
    {
        powerOn = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F" + "\n" + "Insert core.";
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
        if (Input.GetKey(KeyCode.F))
        {
            powerOn = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }
}
