using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    [SerializeField] Color nonPlaceable;
    [SerializeField] Color placeable;
    public GameObject thePlaceable;
    bool canPlace;

    private void Update()
    {
        if(thePlaceable != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            thePlaceable.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            if (Input.GetMouseButton(0) && canPlace)
            {
                thePlaceable.GetComponent<SpriteRenderer>().color = Color.white;
                thePlaceable = null;
                canPlace = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Placeable" && thePlaceable != null)
        {
            thePlaceable.GetComponent<SpriteRenderer>().color = placeable;
            canPlace = true;
        }
        else if(thePlaceable != null)
        {
            thePlaceable.GetComponent<SpriteRenderer>().color = nonPlaceable;
            canPlace = false;
        }
    }
}
