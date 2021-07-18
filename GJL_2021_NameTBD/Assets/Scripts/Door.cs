using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D myCollider;
    [SerializeField] Animator animator;
    [SerializeField] StudioEventEmitter openSound;

    public void Start()
    {
        animator = GetComponent<Animator>();
        if(openSound.enabled == true)
        {
            openSound.enabled = false;
        }
    }

    public void Open()
    {
        myCollider.enabled = false;
        animator.SetBool("Open", true);
        openSound.enabled = true;
    }

    public void Close()
    {
        myCollider.enabled = true;
        animator.SetBool("Open", false);
        openSound.enabled = false;
    }
}
