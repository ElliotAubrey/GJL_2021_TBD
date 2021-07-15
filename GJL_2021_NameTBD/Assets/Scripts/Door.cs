using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D myCollider;

    public void Open()
    {
        myCollider.enabled = false;
    }

    public void Close()
    {
        myCollider.enabled = true;
    }
}
