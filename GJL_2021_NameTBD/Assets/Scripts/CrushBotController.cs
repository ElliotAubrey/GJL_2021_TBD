using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CrushBotController : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] HackTerminalBot hackTerminal;
    [SerializeField] StudioListener listener;
    [SerializeField] StudioEventEmitter voice;
    [SerializeField] StudioEventEmitter moveSound;
    [SerializeField] StudioEventEmitter drillSound;

    public bool onBelt = false;
    public bool canControl = false;
    public Rigidbody2D body;
    float speed;
    float horizontal;
    float vertical;
    Vector2 previousInput;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canControl && listener.attenuationObject != gameObject)
        {
            listener.attenuationObject = gameObject;
            if (voice.enabled == true)
            {
                voice.enabled = false;
            }
            voice.enabled = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            hackTerminal.Return(false);
            canControl = false;
            listener.attenuationObject = FindObjectOfType<PlayerMovement>().gameObject;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 && vertical != 0)
        {
            if (previousInput == Vector2.right || previousInput == -Vector2.right)
            {
                vertical = 0;
            }
            else
            {
                horizontal = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (canControl)
        {
            previousInput = new Vector2(horizontal, vertical);
            Vector2 movement = new Vector2(horizontal, vertical).normalized * speed;
            body.velocity = movement;

            SwitchAnimation(new Vector2(horizontal, vertical));

            if (movement != Vector2.zero && !moveSound.isActiveAndEnabled && !onBelt)
            {
                moveSound.enabled = true;
            }
            if (movement == Vector2.zero && moveSound.isActiveAndEnabled)
            {
                moveSound.enabled = false;
            }
            if (onBelt)
            {
                moveSound.enabled = false;
            }
            if (!canControl)
            {
                moveSound.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CrushBox" && Input.GetKey(KeyCode.F))
        {
            if(drillSound.enabled == true)
            {
                drillSound.enabled = false;
            }
            drillSound.enabled = true;
        }
    }

    public void SwitchAnimation(Vector2 direction)
    {
        if (body.velocity.magnitude > 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        switch (direction.x)
        {
            case -1:
                animator.SetInteger("Direction", 1);
                rend.flipX = false;
                break;
            case 1:
                animator.SetInteger("Direction", 1);
                rend.flipX = true;
                break;
        }

        switch (direction.y)
        {
            case -1:
                animator.SetInteger("Direction", 0);
                rend.flipX = false;
                break;
            case 1:
                animator.SetInteger("Direction", 2);
                rend.flipX = false;
                break;
        }
    }

    public void PurposeFulfilled()
    {
        hackTerminal.Return(true);
        Destroy(gameObject);
        canControl = false;
        listener.attenuationObject = FindObjectOfType<PlayerMovement>().gameObject;
    }
}
