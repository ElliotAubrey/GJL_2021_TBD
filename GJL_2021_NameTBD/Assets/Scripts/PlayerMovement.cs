using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer rend;

    public StudioEventEmitter moveSound;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 && vertical !=0)
        {
            if(previousInput == Vector2.right || previousInput == -Vector2.right)
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
            body.bodyType = RigidbodyType2D.Dynamic;
            previousInput = new Vector2(horizontal, vertical);
            Vector2 movement = new Vector2(horizontal, vertical).normalized * speed;

            if(movement != Vector2.zero && !moveSound.isActiveAndEnabled && !onBelt)
            {
                moveSound.enabled = true;
            }
            if(movement == Vector2.zero && moveSound.isActiveAndEnabled)
            {
                moveSound.enabled = false;
            }
            if(onBelt)
            {
                moveSound.enabled = false;
            }
            if(!canControl)
            {
                moveSound.enabled = false;
            }

            body.velocity = movement;
            SwitchAnimation(new Vector2(horizontal, vertical));
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

}
