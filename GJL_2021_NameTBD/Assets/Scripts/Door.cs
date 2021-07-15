using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D myCollider;
    [SerializeField] Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Open()
    {
        myCollider.enabled = false;
        animator.SetBool("Open", true);
    }

    public void Close()
    {
        myCollider.enabled = true;
        animator.SetBool("Open", false);
    }
}
