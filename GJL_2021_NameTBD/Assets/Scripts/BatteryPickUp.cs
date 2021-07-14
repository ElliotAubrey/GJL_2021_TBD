using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] int amount = 1;
    PlayerPower playerPower;

    private void Start()
    {
        playerPower = GameObject.FindObjectOfType<PlayerPower>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerPower.BatteryPickUp(amount);
        Destroy(gameObject.transform.parent.gameObject);
    }
}