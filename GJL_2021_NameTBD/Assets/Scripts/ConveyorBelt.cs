using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float speed;


    Vector2 direction;
    PlayerMovement playerMovement;
    Rigidbody2D body;

    private void Update()
    {
        direction = (start.transform.position - end.transform.position).normalized;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(playerMovement == null)
            {
                playerMovement = collision.GetComponent<PlayerMovement>();
                body = collision.GetComponent<Rigidbody2D>();
            }
            playerMovement.canControl = false;
        }
        body.velocity = direction * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.canControl = true;
    }
}
