using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerPercentageHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerPercentage;
    [SerializeField] Slider slider;

    // Update is called once per frame
    void Update()
    {
        powerPercentage.text = slider.value.ToString() + "%";
    }
}
