using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireRandomiser : MonoBehaviour
{
    [SerializeField] WireStart[] wireStarts;
    [SerializeField] WireEnd[] wireEnds;

    WireStart[] wireStartsToRandomise = new WireStart[4];
    WireEnd[] wireEndsToRandomise = new WireEnd[4];

    Vector2 sp1, sp2, sp3, sp4;
    Vector2 ep1, ep2, ep3, ep4;

    private void Start()
    {
        sp1 = wireStarts[0].transform.position;
        sp2 = wireStarts[1].transform.position;
        sp3 = wireStarts[2].transform.position;
        sp4 = wireStarts[3].transform.position;

        ep1 = wireEnds[0].transform.position;
        ep2 = wireEnds[1].transform.position;
        ep3 = wireEnds[2].transform.position;
        ep4 = wireEnds[3].transform.position;

        for(int i = 0; i < wireStarts.Length; i++)
        {
            wireStartsToRandomise[i] = wireStarts[i];
            wireEndsToRandomise[i] = wireEnds[i];
        }

        Randomise();
    }

    public void Randomise()
    {
        for (int i = 0; i < wireStarts.Length; i++)
        {
            int moveValue = Random.Range(0, 3);
            int arrayPos = i + moveValue;
            if(arrayPos> wireStarts.Length-1)
            {
                arrayPos -= 4;
            }
            Debug.Log(arrayPos);
            SwapPositionsStarts(wireStartsToRandomise[i].transform, wireStartsToRandomise[arrayPos].transform);
        }

        for (int i = 0; i < wireStarts.Length; i++)
        {
            int moveValue = Random.Range(0, 3);
            int arrayPos = i + moveValue;
            if (arrayPos > wireStarts.Length-1)
            {
                arrayPos -= 4;
            }
            SwapPositionsEnds(wireEndsToRandomise[i].transform, wireEndsToRandomise[arrayPos].transform);
        }
    }

    void SwapPositionsStarts(Transform wire1, Transform wire2)
    {
        Vector2 mid = wire2.transform.position;

        wire2.transform.position = wire1.transform.position;
        wire1.transform.position = mid;
    }

    void SwapPositionsEnds(Transform wire1, Transform wire2)
    {
        Vector2 mid = wire2.transform.position;

        wire2.transform.position = wire1.transform.position;
        wire1.transform.position = mid;
    }

}

