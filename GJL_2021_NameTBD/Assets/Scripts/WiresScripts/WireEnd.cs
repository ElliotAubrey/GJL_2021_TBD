using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireEnd : MonoBehaviour
{
    public static bool wireSelected = false;

    public bool correct = false;
    public bool attached = false;

    [SerializeField] string color;

    WireStart wireStart;

    private void Start()
    {
        wireStart = GameObject.FindObjectOfType<WireStart>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && wireSelected && !attached)
        {
            wireSelected = false;
            Wire wire = wireStart.GetSelectedWire();
            wire.set = true;
            wire.setPos = transform.position;
            wire.selected = false;
            attached = true;
            if(wire.color == color)
            {
                correct = true;
            }
        }
    }
}
