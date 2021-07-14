using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] string message;
    [SerializeField] bool triggerOnce;

    TextboxController textBoxController;
    bool triggered;

    private void Awake()
    {
        textBoxController = GameObject.FindObjectOfType<TextboxController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && triggerOnce && !triggered)
        {
            textBoxController.CreateTextBox(name, message);
            triggered = true;
        }
        else if (collision.tag == "Player" && !triggerOnce)
        {
            textBoxController.CreateTextBox(name, message);
            triggered = true;
        }
    }
}
