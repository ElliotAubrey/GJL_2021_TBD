using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] float neededMass;
    bool open = false;
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
            //close code
        }
    }

}
