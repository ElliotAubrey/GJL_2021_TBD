using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI batteriesUI;

    public int power = 100;
    public bool losePower = true;

    int batteries = 1;
    PlayerMovement playerMovement;
    int powerTimer = 50;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        batteriesUI.text = batteries.ToString();
    }

    public void BatteryPickUp(int amount)
    {
        batteries += amount;
        batteriesUI.text = batteries.ToString();
    }

    private void Update()
    {
        slider.value = power;

        if(power < 1 && batteries < 1)
        {
            playerMovement.canControl = false;
        }

        if(power == 0 && batteries > 0)
        {
            batteries--;
            power = 100;
            batteriesUI.text = batteries.ToString();
        }
    }

    private void FixedUpdate()
    {
        if(playerMovement.body.velocity.x != 0 || playerMovement.body.velocity.y != 0)
        {
            powerTimer -= 2;
        }
        else
        {
            powerTimer--;
        }

        if (powerTimer < 1 && power > 0)
        {
            if(losePower)
            {
                power--;
            }
            powerTimer = 50;
        }
    }
}
