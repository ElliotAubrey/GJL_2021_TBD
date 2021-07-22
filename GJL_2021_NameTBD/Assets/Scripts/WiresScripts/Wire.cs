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
            wirePickUp.enabled = true;
            wireHold.enabled = true;
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            wirePickUp.enabled = false;
            wireHold.enabled = false;
        }
        

        if (set)
        {
            wireDrop.enabled = true;
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, setPos);
        }
    }
}
