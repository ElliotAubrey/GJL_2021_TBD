using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objective : MonoBehaviour
{
    [SerializeField] Generator gen1, gen2, gen3;
    [SerializeField] TextMeshProUGUI objPrompt;
    [SerializeField] Door finalDoor;

    int generatorCount = 0;
    bool g1, g2, g3;
    void FixedUpdate()
    {
        if(g1 && g2 && g3)
        {
            objPrompt.text = "Find the main power switch";
            if (finalDoor.open == false)
            {
                finalDoor.Open();
            }
        }
        else
        {
            objPrompt.text = "Turn on generators " + generatorCount + "/3";
        }
    }

    public void NewGen()
    {
        generatorCount++;
        if (!g3 && g2 && g1)
        {
            g3 = true;
        }
        if (!g2 && g1)
        {
            g2 = true;
        }
        if (!g1)
        {
            g1 = true;
        }
    }

}
