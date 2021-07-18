using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Music : MonoBehaviour
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
    }

    void FixedUpdate()
    {
        instance.setParameterByName("Success Level", SucessLevel);
        instance.setParameterByName("Power", Power);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "MusicReset")
        {
            Debug.Log("DESTROY MUSIC");
            Destroy(gameObject);
        }
    }
}
