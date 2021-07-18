using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using FMODUnity;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    [SerializeField] Image batteryUI;
    [SerializeField] TextMeshProUGUI lowPowerPrompt;
    [SerializeField] StudioEventEmitter lowPower;
    [SerializeField] StudioEventEmitter batteryChange;
    [SerializeField] StudioEventEmitter batteryPickup;

    public int power = 100;
    public bool losePower = true;
    public bool needsReload = false;

    bool spareBattery = false;
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
            if(batteryPickup.enabled == true)
            {
                batteryPickup.enabled = false;
            }
            batteryPickup.enabled = true;
            spareBattery = true;
            x = true;
            losePower = true;
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
            playerMovement.body.velocity = Vector2.zero;
            lowPowerPrompt.text = "Dead";
            StartCoroutine(Dead());
        }

        if(power == 0 && spareBattery)
        {
            batteryUI.gameObject.SetActive(false);
            spareBattery = false;
            power = 100;
            if(batteryChange.enabled == true)
            {
                batteryChange.enabled = false;
            }
            batteryChange.enabled = true;
        }

        if(power<=20 && power > 0)
        {
            lowPowerPrompt.gameObject.SetActive(true);
            lowPowerPrompt.text = "Low Power!";
            lowPowerPrompt.color = gradient.Evaluate(slider.normalizedValue);
            if(lowPower.enabled == false)
            {
                lowPower.enabled = true;
            }
        }
        else if(power > 20)
        {
            lowPowerPrompt.gameObject.SetActive(false);
            if (lowPower.enabled == true)
            {
                lowPower.enabled = false;
            }
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

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3);
        {
            Debug.Log("Loaded");
            SceneManager.LoadScene("Menu");
        }
    }
}
