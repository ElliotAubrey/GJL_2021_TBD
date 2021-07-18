using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] DialogSO dialogSO;
    [SerializeField] Transform textBox;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] bool triggerOnce, final;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerPower playerPower;
    [SerializeField] GameObject finalOverlay;

    bool triggered, isPlaying;
    int amountOfText;

    // Start is called before the first frame update
    void Start()
    {
        amountOfText = dialogSO.dialog.Length;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && triggerOnce && !triggered || collision.tag == "StrongBot" && triggerOnce && !triggered)
        {
            triggered = true;
        }
        else if (collision.tag == "Player" && !triggerOnce || collision.tag == "StrongBot" && !triggerOnce)
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
                if (final == true)
                {
                    FinalMessage();
                }
                else
                {
                    CloseTextBox();
                }
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
            case 11:
                text.text = dialogSO.dialog[10];
                amountOfText = amountOfText - 1;
                break;
            case 12:
                text.text = dialogSO.dialog[11];
                amountOfText = amountOfText - 1;
                break;
            case 13:
                text.text = dialogSO.dialog[12];
                amountOfText = amountOfText - 1;
                break;
            case 14:
                text.text = dialogSO.dialog[13];
                amountOfText = amountOfText - 1;
                break;
            case 15:
                text.text = dialogSO.dialog[14];
                amountOfText = amountOfText - 1;
                break;
            case 16:
                text.text = dialogSO.dialog[15];
                amountOfText = amountOfText - 1;
                break;
            case 17:
                text.text = dialogSO.dialog[16];
                amountOfText = amountOfText - 1;
                break;
            case 18:
                text.text = dialogSO.dialog[17];
                amountOfText = amountOfText - 1;
                break;
            case 19:
                text.text = dialogSO.dialog[18];
                amountOfText = amountOfText - 1;
                break;
            case 20:
                text.text = dialogSO.dialog[19];
                amountOfText = amountOfText - 1;
                break;
        }
    }

    public void OpenTextBox()
    {
        textBox.gameObject.SetActive(true);
        ReadDialog();
        playerMovement.canControl = false;
        playerPower.losePower = false;
        playerMovement.body.velocity = Vector2.zero;
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

        playerMovement.canControl = true;
        playerPower.losePower = true;
    }

    public void FinalMessage()
    {
        finalOverlay.SetActive(true);
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
