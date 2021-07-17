using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Sprite pressureOn, pressureOff;
    [SerializeField] Door[] doors;
    [SerializeField] StudioEventEmitter soundObject;
    [SerializeField] StudioListener listener;

    bool powered = false;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PushBox")
        {
            soundObject.gameObject.SetActive(true);
            rend.sprite = pressureOn;
            for(int i = 0; i < doors.Length; i++)
            {
                doors[i].Open();
            }
        }
    }


}
