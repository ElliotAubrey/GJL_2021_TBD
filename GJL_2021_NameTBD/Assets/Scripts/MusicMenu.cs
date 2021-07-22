using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    [SerializeField] FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    [SerializeField]
    [Range(0f, 3f)]
    public float SucessLevel;

    [SerializeField]
    [Range(0f, 100f)]
    public float Power;

    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
        instance.setParameterByName("Success Level", 3f);
    }
    public void PlayGame()
    {
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
