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
        sucessLevel += successAdded;
        if(sucessLevel>3)
        {
            sucessLevel = 3;
        }
    }

    public void PuzzleFailed()
    {
        sucessLevel -= successRemoved;
        if(sucessLevel<0)
        {
            sucessLevel = 0;
        }
    }

    private void FixedUpdate()
    {
        music.SucessLevel = sucessLevel;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MusicReset")
        {
            sucessLevel = 0;
        }
    }
}
