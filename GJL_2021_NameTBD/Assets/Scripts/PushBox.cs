using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    Vector2 startPos;
    bool set = false;
    public bool onBelt;
    bool setOffBelt = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StrongBot")
        {
            body.mass = 1;
        }
        else
        {
            body.mass = 999999999;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "StrongBot")
        {
            body.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        body.velocity = Vector2.zero;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PressurePlate")
        {
            set = true;
            transform.position = collision.gameObject.transform.position + new Vector3(0, 0.5f, 0);
            body.bodyType = RigidbodyType2D.Static;
        }
    }

    private void Update()
    {
        if(!spriteRenderer.isVisible && !set)
        {
            transform.position = startPos;
        }
    }
}
