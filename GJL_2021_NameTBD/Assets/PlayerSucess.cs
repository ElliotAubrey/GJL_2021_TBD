using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuccess : MonoBehaviour
{
    [SerializeField] float successAdded;
    [SerializeField] float successRemoved;

    float sucessLevel = 0;

    public void PuzzleComplete()
    {
        sucessLevel += successAdded;
    }

    public void PuzzleFailed()
    {
        sucessLevel -= successRemoved;
    }
}
