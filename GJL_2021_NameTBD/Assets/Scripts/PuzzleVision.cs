using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PuzzleVision : MonoBehaviour
{
    [SerializeField] CinemachineTargetGroup target;
    [SerializeField] int layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target.m_Targets[layer].weight = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            target.m_Targets[layer].weight = 0;
        }
    }
}

