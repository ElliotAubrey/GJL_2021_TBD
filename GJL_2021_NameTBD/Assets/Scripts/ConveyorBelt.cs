using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField] float speed;
    [SerializeField] bool horizontal;

    Vector2 direction;
    PlayerMovement playerMovement;
    Rigidbody2D body;

    private void Update()
    {
        direction = (end.transform.position - start.transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerMovement == null)
        {
            playerMovement = collision.GetComponent<PlayerMovement>();
            body = collision.GetComponent<Rigidbody2D>();
        }

        if (collision.tag == "Player")
        {
            playerMovement.canControl = false;
            if(horizontal)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, transform.position.y, collision.gameObject.transform.position.z);
            }
            else
            {
                collision.gameObject.transform.position = new Vector3(transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerMovement.canControl = false;
        }
        body.velocity = direction * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.canControl = true;
        body.velocity = Vector2.zero;
    }
}
