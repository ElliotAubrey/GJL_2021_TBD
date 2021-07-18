using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParametersStrongBot : MonoBehaviour
{
    [SerializeField] Door[] doors;
    [SerializeField] StrongBotController bot;

    int doorsOpen = 0;
    private void FixedUpdate()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].open)
            {
                doorsOpen++;
            }
            if (doors.Length == doorsOpen)
            {
                bot.PurposeFulfilled();
            }
        }
        doorsOpen = 0;
    }
}
