using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Sprite pressureOn, pressureOff;
    [SerializeField] Door[] doors;
    bool powered = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PushBox")
        {
            rend.sprite = pressureOn;
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].Open();
            }
        }
    }


}
