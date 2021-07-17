using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    [SerializeField] Image batteryUI;
    [SerializeField] Sprite emptyBattery;
    [SerializeField] TextMeshProUGUI lowPowerPrompt;

    public int power = 100;
    public bool losePower = true;
    public bool needsReload = false;

    bool spareBattery = true;
    PlayerMovement playerMovement;
    int powerTimer = 50;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public bool BatteryPickUp()
    {
        bool x = false;
        if(!spareBattery)
        {
            spareBattery = true;
            x = true;
            batteryUI.gameObject.SetActive(true);
        }
        return x;
    }

    private void Update()
    {
        slider.value = power;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if(power < 1 && !spareBattery)
        {
            playerMovement.canControl = false;
            //death code
        }

        if(power == 0 && spareBattery)
        {
            batteryUI.gameObject.SetActive(false);
            spareBattery = false;
            power = 100;
        }

        if(power<=20 && power > 0)
        {
            lowPowerPrompt.gameObject.SetActive(true);
            lowPowerPrompt.text = "Low Power!";
            lowPowerPrompt.color = gradient.Evaluate(slider.normalizedValue);
        }
        else if(power > 20)
        {
            lowPowerPrompt.gameObject.SetActive(false);
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
