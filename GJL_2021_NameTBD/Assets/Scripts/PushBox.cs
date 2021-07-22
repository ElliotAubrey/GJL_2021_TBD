using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using TMPro;

public class PushBox : MonoBehaviour
{
    [SerializeField] StudioEventEmitter push;
    [SerializeField] TextMeshProUGUI prompt;

    SpriteRenderer spriteRenderer;
    Rigidbody2D body;
    Vector2 startPos;
    bool set = false;
    public bool onBelt;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "StrongBot" || collision.gameObject.tag == "Conveyor")
        {
            if(collision.gameObject.tag == "StrongBot" && push.enabled == false)
            {
               push.enabled = true;
            }
            body.mass = 1;
        }
        else if(collision.gameObject.tag != "ConveyorBelt")
        {
            body.mass = 999999999;
            prompt.gameObject.SetActive(true);
            if (collision.gameObject.tag == "Player")
            {
                prompt.text = "[I wonder another bot could push this?]";
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.gameObject.tag != "StrongBot" || collision.gameObject.tag != "Conveyor")
       {
            body.velocity = Vector2.zero;
            Debug.Log(collision.gameObject.name);
       }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        body.velocity = Vector2.zero;
        prompt.gameObject.SetActive(false);
        push.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PressurePlate" && collision.gameObject.GetComponent<PressurePlate>().GetPushBox().set == false)
        {
            Debug.Log("IN");
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
