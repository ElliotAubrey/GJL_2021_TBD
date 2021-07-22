using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Sprite pressureOn, pressureOff;
    [SerializeField] Door[] doors;
    [SerializeField] StudioEventEmitter activated;

    PushBox myBox;
    bool powered = false;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        myBox = new PushBox();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PushBox")
        {
            if(myBox == null)
            {
                myBox = collision.gameObject.GetComponent<PushBox>();
            }
            activated.enabled = true;
            rend.sprite = pressureOn;
            for(int i = 0; i < doors.Length; i++)
            {
                if(doors[i] != null)
                {
                    doors[i].Open();
                }
            }
        }
    }

    public PushBox GetPushBox()
    {
        return myBox;
    }


}
