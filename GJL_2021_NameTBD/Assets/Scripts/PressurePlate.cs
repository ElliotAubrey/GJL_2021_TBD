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

    public bool powered = false;

    private void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PushBox" && !powered)
        {
            PowerOnDelay();
            if (activated.enabled == true)
            {
                activated.enabled = false;
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

    IEnumerator PowerOnDelay()
    {
        yield return new WaitForSeconds(1f);
        powered = true;
        Debug.Log("Powered");
    }


}
