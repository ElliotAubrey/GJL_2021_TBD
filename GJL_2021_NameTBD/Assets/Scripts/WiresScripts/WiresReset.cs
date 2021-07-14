using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresReset : MonoBehaviour
{
    [SerializeField] GameObject hackingPuzzle;
    bool first = true;
    GameObject go;
    private void Start()
    {
        go = gameObject;
    }
    public void Reset()
    {
        if(first)
        {
            Destroy(gameObject);
            go = Instantiate(hackingPuzzle, transform.position, transform.rotation);
            first = false;
        }
        else
        {
            go = Instantiate(hackingPuzzle, transform.position, transform.rotation);
        }
    }

    public void Win()
    {
        Destroy(go);
    }
}
