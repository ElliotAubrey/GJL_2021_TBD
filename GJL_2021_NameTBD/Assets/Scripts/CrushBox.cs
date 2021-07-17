using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrushBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CrushBot")
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "F to destroy";
        }
        else
        {
            prompt.gameObject.SetActive(true);
            prompt.text = "[Perhaps another bot can destroy this?]";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && collision.gameObject.tag == "CrushBot")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }
}
