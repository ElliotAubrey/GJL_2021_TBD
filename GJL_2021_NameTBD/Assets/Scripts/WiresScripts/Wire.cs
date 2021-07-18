using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Wire : MonoBehaviour
{
    [SerializeField] WireStart wireStart;
    [SerializeField] StudioEventEmitter wirePickUp;
    [SerializeField] StudioEventEmitter wireDrop;
    [SerializeField] StudioEventEmitter wireHold;
    

    public LineRenderer lineRenderer;
    public string color;
    public bool set = false;
    public bool selected = false;
    public Vector2 setPos;

    private void Update()
    {
        if (selected)
        {
            wireHold.enabled = true;
            if(wirePickUp.enabled == true)
            {
                wirePickUp.enabled = false;
            }
            wirePickUp.enabled = true;
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            wireHold.enabled = false;
        }
        

        if (set)
        {
            if (wireDrop.enabled == true)
            {
                wireDrop.enabled = false;
            }
            wireDrop.enabled = true;
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, setPos);
        }
    }
}
