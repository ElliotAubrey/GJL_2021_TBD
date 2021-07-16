using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BatteryUI : MonoBehaviour
{
    [SerializeField] Image battery;
    [SerializeField] RectTransform baseObject;
    [SerializeField] RectTransform movingObject;
    [SerializeField] GameObject reloadPoint;

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

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
