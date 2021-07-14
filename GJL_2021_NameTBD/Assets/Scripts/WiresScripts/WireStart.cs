using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireStart : MonoBehaviour
{
    [SerializeField] Wire myWire;
    [SerializeField] Wire[] allWires;

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for(int i = 0; i < allWires.Length; i++)
            {
                if (allWires[i].set == false)
                {
                    allWires[i].selected = false;
                    allWires[i].lineRenderer.enabled = false;
                }
                WireEnd.wireSelected = true;
            }
            myWire.lineRenderer.enabled = true;
            myWire.selected = true;
        }
    }

    public Wire GetSelectedWire()
    {
        Wire wire = null;
        for(int i = 0; i < allWires.Length; i++)
        {
            if(allWires[i].selected)
            {
                wire = allWires[i];
            }
        }
        return wire;
    }

    public void Reset()
    {
        for (int i = 0; i < allWires.Length; i++)
        {
            if (allWires[i].set == false)
            {
                allWires[i].selected = false;
                allWires[i].lineRenderer.enabled = false;
                allWires[i].set = false;
            }
            WireEnd.wireSelected = false;
        }
    }
}
