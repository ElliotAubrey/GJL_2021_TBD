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
    [SerializeField] Image battery1;
    [SerializeField] Image battery2;
    [SerializeField] TextMeshProUGUI lowPowerPrompt;

    public int power = 100;
    public bool losePower = true;
    public bool needsReload = false;

    int batteries = 1;
    PlayerMovement playerMovement;
    int powerTimer = 50;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void BatteryPickUp(int amount)
    {
        if(batteries < 1)
        {
            batteries += amount;
        }
    }

    private void Update()
    {
        slider.value = power;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        if(power < 1 && batteries < 1)
        {
            playerMovement.canControl = false;
        }

        if(power == 0 && batteries > 0)
        {
            lowPowerPrompt.text = "Battery Change Required!";
            playerMovement.canControl = false;
            playerMovement.body.velocity = Vector2.zero;
            needsReload = true;
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
