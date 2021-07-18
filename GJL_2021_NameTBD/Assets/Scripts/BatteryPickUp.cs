using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    PlayerPower playerPower;

    private void Start()
    {
        playerPower = GameObject.FindObjectOfType<PlayerPower>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(playerPower.BatteryPickUp())
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}