using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] float neededMass;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Sprite pressureOn, pressureOff;
    bool open = false;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>().mass >= neededMass && !open)
        {
            open = true;
            //open code  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(open)
        {
            rend.sprite = pressureOn;
            //close code
        }
        else
        {
            rend.sprite = pressureOff;
        }
    }

}
