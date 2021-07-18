using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParametersCrushBot : MonoBehaviour
{
    [SerializeField] CrushBox[] boxes;
    [SerializeField] CrushBotController bot;

    int boxesCrushed = 0;
    private void FixedUpdate()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i] == null)
            {
                boxesCrushed++;
            }
            if (boxesCrushed == boxes.Length)
            {
                bot.PurposeFulfilled();
            }
        }
        boxesCrushed = 0;
    }
}
