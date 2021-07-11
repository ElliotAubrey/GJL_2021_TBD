using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Collected");
        //Method call to add whatever powerup
    }
}