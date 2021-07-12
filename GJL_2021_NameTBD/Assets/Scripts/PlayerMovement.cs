using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    public bool canControl = false;
    Rigidbody2D body;
    float speed;
    float horizontal;
    float vertical;
    Vector2 previousInput;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
            previousInput = new Vector2(horizontal, vertical);
            Vector2 movement = new Vector2(horizontal, vertical).normalized * speed;
            body.velocity = movement;
        }
    }

}
