using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class DepthSortByY : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        TilemapRenderer colRend = collision.transform.GetComponent<TilemapRenderer>();
        SpriteRenderer colSpriteRend = collision.transform.GetComponent<SpriteRenderer>();
        SpriteRenderer rend = GetComponent<SpriteRenderer>();

        if (colRend == null)
        {
            if (colSpriteRend.sortingOrder < 2)
            {
                rend.sortingOrder = 1;
            }
        }
        else if (colSpriteRend == null)
        {
            if (colRend.sortingOrder == 2)
            {
                rend.sortingOrder = 1;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = 3;
    }
}
