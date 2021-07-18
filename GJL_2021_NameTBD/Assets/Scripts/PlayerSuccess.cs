using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PlayerSucess : MonoBehaviour
{
    [SerializeField] float successAdded;
    [SerializeField] float successRemoved;
    [SerializeField] StudioGlobalParameterTrigger music;

    public float sucessLevel = 3;

    public void PuzzleComplete()
    {
        sucessLevel += successAdded;
        music.value = sucessLevel;
    }

    public void PuzzleFailed()
    {
        sucessLevel -= successRemoved;
        music.value = sucessLevel;
    }
}
