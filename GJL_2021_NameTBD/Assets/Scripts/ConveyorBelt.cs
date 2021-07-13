using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float speed;

    public bool horizontal;

    Vector2 direction;
    PlayerMovement playerMovement;
    PlayerPower playerPower;


    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerPower = FindObjectOfType<PlayerPower>();
    }
    private void Update()
    {
        direction = (end.transform.position - start.transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(horizontal )
        {
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y, collision.gameObject.transform.position.z);
        }
        else
        {
            collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.canControl = false;
        playerPower.losePower = false;
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
        collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void Switch()
    {
        Transform mid = end;

        end = start;
        start = mid;
    }
}
