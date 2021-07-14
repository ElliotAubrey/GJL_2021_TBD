using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresLogic : MonoBehaviour
{
    [SerializeField] WireStart wireStart;
    [SerializeField] WireEnd[] wireEnds;
    [SerializeField] Wire[] allWires;
    [SerializeField] WiresReset wiresReset;
    [SerializeField] WireRandomiser wireRandomiser;

    bool b1 = false;
    bool b2 = false;
    bool b3 = false;
    bool b4 = false;

    void Update()
    {
        b1 = wireEnds[0].correct;
        b2 = wireEnds[1].correct;
        b3 = wireEnds[2].correct;
        b4 = wireEnds[3].correct;

        if(b1 && b2 && b3 && b4)
        {
            wiresReset.Win();
        }
        else if(wireEnds[1].attached && wireEnds[2].attached && wireEnds[3].attached && wireEnds[0].attached)
        {
            wiresReset.Reset();
            wireRandomiser.Randomise();
        }
    }
}
