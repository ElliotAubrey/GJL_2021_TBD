using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresReset : MonoBehaviour
{
    [SerializeField] GameObject hackingPuzzle;
    public void Reset()
    {
        Destroy(gameObject);
        Instantiate(hackingPuzzle, transform.position, transform.rotation);
    }

    public void Win()
    {
        Destroy(gameObject);
    }
}
