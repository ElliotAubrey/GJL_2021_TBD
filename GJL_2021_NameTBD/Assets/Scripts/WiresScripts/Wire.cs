using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] WireStart wireStart;

    public LineRenderer lineRenderer;
    public string color;
    public bool set = false;
    public bool selected = false;
    public Vector2 setPos;

    private void Update()
    {
        if (selected)
        {
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if(set)
        {
            lineRenderer.SetPosition(0, wireStart.transform.position);
            lineRenderer.SetPosition(1, setPos);
        }
    }
}
