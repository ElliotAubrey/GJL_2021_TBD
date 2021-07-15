using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] DialogSO dialogSO;
    [SerializeField] Transform textBox;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] bool triggerOnce;

    bool triggered, isPlaying;
    int amountOfText;

    // Start is called before the first frame update
    void Start()
    {
        amountOfText = dialogSO.dialog.Length;
        textBox = GameObject.Find("TextBox").transform;
        text = textBox.Find("Text").gameObject.GetComponent<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && triggerOnce && !triggered)
        {
            triggered = true;

        }
        else if (collision.tag == "Player" && !triggerOnce)
        {
            triggered = true;
        }
    }

    private void Update()
    {
        if (amountOfText >= 0 && triggered == true && isPlaying == false)
        {
            isPlaying = true;
            OpenTextBox();
        }
        else if (amountOfText >= 0 && triggered == true && textBox.gameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            ReadDialog();
        }
    }

    public void ReadDialog()
    {
        switch (amountOfText)
        {
            case 0:
                CloseTextBox();
                break;
            case 1:
                text.text = dialogSO.dialog[0];
                amountOfText = amountOfText - 1;
                break;
            case 2:
                text.text = dialogSO.dialog[1];
                amountOfText = amountOfText - 1;
                break;
            case 3:
                text.text = dialogSO.dialog[2];
                amountOfText = amountOfText - 1;
                break;
            case 4:
                text.text = dialogSO.dialog[3];
                amountOfText = amountOfText - 1;
                break;
            case 5:
                text.text = dialogSO.dialog[4];
                amountOfText = amountOfText - 1;
                break;
            case 6:
                text.text = dialogSO.dialog[5];
                amountOfText = amountOfText - 1;
                break;
            case 7:
                text.text = dialogSO.dialog[6];
                amountOfText = amountOfText - 1;
                break;
            case 8:
                text.text = dialogSO.dialog[7];
                amountOfText = amountOfText - 1;
                break;
            case 9:
                text.text = dialogSO.dialog[8];
                amountOfText = amountOfText - 1;
                break;
            case 10:
                text.text = dialogSO.dialog[9];
                amountOfText = amountOfText - 1;
                break;

        }
    }

    public void OpenTextBox()
    {
        textBox.gameObject.SetActive(true);
        ReadDialog();
    }

    public void CloseTextBox()
    {
        textBox.gameObject.SetActive(false);

        if (triggerOnce == false)
        {
            triggered = false;
            isPlaying = false;
            amountOfText = dialogSO.dialog.Length;
        }
    }
}
