using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class BankLoader : MonoBehaviour
{
    private void Awake()
    {
        RuntimeManager.LoadBank("Master.bytes");
    }

    private void OnDestroy()
    {
        RuntimeManager.UnloadBank("Master.bytes");
    }
}
