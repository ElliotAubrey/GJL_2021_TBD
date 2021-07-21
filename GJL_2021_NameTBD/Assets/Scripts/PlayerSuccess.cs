using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlayerSucess : MonoBehaviour
{
    [SerializeField] float successAdded;
    [SerializeField] float successRemoved;
    [SerializeField] Music music;

    public float sucessLevel = 3;

    public void PuzzleComplete()
    {
        if(sucessLevel + successAdded < 3)
        {
            sucessLevel += successAdded;
            music.SucessLevel = sucessLevel;
        }
    }

    public void PuzzleFailed()
    {
        if (sucessLevel - successRemoved > 0)
        {
            sucessLevel -= successRemoved;
            music.SucessLevel = sucessLevel;
        }
    }
}
