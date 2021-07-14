using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBox : MonoBehaviour
{
    [SerializeField] float mass;

    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    Vector2 startPos;
    bool set = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        body.bodyType = RigidbodyType2D.Static;
        body.mass = mass;
        startPos = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StrongBot" && !set)
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            body.mass = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StrongBot")
        {
            body.bodyType = RigidbodyType2D.Static;
            body.mass = mass;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PressurePlate")
        {
            set = true;
            transform.position = collision.gameObject.transform.position;
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
