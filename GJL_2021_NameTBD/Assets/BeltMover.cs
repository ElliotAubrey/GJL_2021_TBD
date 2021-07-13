using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeltMover : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI prompt;
    [SerializeField] ConveyorBelt[] belts;
    [SerializeField] bool horizontal;

    [SerializeField] Sprite[] lever;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] bool on;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    int cooldown = 0;
    private void FixedUpdate()
    {
        if(cooldown > 0)
        {
            cooldown--;
        }

        switch (on)
        {
            case true:
                rend.sprite = lever[0];
                break;
            case false:
                rend.sprite = lever[1];
                break;
        }
;    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(true);
        prompt.text = "F";
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && cooldown == 0)
        {
            Debug.Log("Switched");
            on = !on;
            for(int i = 0; i < belts.Length; i++)
            {
                belts[i].Switch();
            }
            cooldown = 50;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.gameObject.SetActive(false);
    }
}
