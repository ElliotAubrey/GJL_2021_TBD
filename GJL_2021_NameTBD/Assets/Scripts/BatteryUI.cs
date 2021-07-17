using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BatteryUI : MonoBehaviour
{
    [SerializeField] Image emptybattery;
    [SerializeField] Image battery;
    [SerializeField] Image batteryPowerBar;
    [SerializeField] RectTransform baseObject;
    [SerializeField] RectTransform movingObject;

    PlayerPower playerPower;
    bool needsReload = false;
    bool moving = false;

    private void Start()
    {
        playerPower = PlayerPower.FindObjectOfType<PlayerPower>();
    }
    private void Update()
    {
        needsReload = playerPower.needsReload;
        if(needsReload)
        {
            Debug.Log(batteryPowerBar);
            batteryPowerBar = emptybattery;
            if (IsMouseOverUI() && Input.GetMouseButtonDown(0))
            {
                moving = true;
            }
        }

        if(moving)
        {
            Vector3 pos = Input.mousePosition;
            pos.z = baseObject.position.z;
            movingObject.position = Camera.main.ScreenToWorldPoint(pos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(moving && collision.tag == "ReloadPoint")
        {
            batteryPowerBar = battery;
            battery = emptybattery;
            batteryPowerBar = battery;
            playerPower.needsReload = false;
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
