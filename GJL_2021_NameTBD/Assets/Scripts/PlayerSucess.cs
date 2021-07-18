using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuccess : MonoBehaviour
{
    [SerializeField] float successAdded;
    [SerializeField] float successRemoved;
    [SerializeField] Music music;
    float sucessLevel = 0;

    public void PuzzleComplete()
    {
        sucessLevel += successAdded;
    }

    public void PuzzleFailed()
    {
        sucessLevel -= successRemoved;
    }

    private void FixedUpdate()
    {
        music.SucessLevel = sucessLevel;
    }
}
