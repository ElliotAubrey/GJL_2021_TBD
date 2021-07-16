using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float speed;
    [SerializeField] Sprite[] arrows;
    [SerializeField] SpriteRenderer rend;

    public bool horizontal;

    Vector2 direction;
    PlayerMovement playerMovement;
    StrongBotController strongBotController;
    PlayerPower playerPower;

    public bool swap;
    [SerializeField] Transform archivedStart, archivedEnd;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerPower = FindObjectOfType<PlayerPower>();
        ForceSwap();
        direction = (end.transform.position - start.transform.position).normalized;
    }
    private void Update()
    {
        switch (horizontal)
        {
            case true:
                switch (swap)
                {
                    case true:
                        ChangeSprite(0);
                        break;
                    case false:
                        ChangeSprite(1);
                        break;
                }
                break;

            case false:
                switch (swap)
                {
                    case true:
                        ChangeSprite(2);
                        break;
                    case false:
                        ChangeSprite(3);
                        break;
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(horizontal == true)
        {
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y + 0.2f, collision.gameObject.transform.position.z);
        }
        else
        {
            collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
        }
        if(collision.gameObject.GetComponent<StrongBotController>() != null)
        {
            strongBotController = collision.gameObject.GetComponent<StrongBotController>();
        }
        playerMovement.onBelt = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerMovement.canControl = false;
            playerPower.losePower = false;
        }

        if (collision.gameObject.tag == "StrongBot")
        {
            strongBotController.canControl = false;
        }
        collision.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerPower.losePower = true;
            if(playerPower.power > 1)
            {
                playerMovement.canControl = true;
            }
        }

        if (collision.gameObject.tag == "StrongBot")
        {
            strongBotController.canControl = true;
        }

        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        playerMovement.onBelt = false;
    }

    public void Switch()
    {
        swap = !swap;
        Transform mid = end;

        end = start;
        start = mid;
        direction = (end.transform.position - start.transform.position).normalized;
    }

    public void ForceSwap()
    {
        switch (swap)
        {
            case true:
                start = archivedEnd;
                end = archivedStart;
                break;
            case false:
                start = archivedStart;
                end = archivedEnd;
                break;
        }
    }

    public void ChangeSprite(int direction)
    {
        switch (direction)
        {
            case 0:
                rend.sprite = arrows[0];
                break;
            case 1:
                rend.sprite = arrows[1];
                break;
            case 2:
                rend.sprite = arrows[2];
                break;
            case 3:
                rend.sprite = arrows[3];
                break;
        }
    }
}
