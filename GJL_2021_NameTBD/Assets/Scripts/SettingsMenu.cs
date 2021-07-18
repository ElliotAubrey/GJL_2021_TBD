using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using FMODUnity;
public class SettingsMenu : MonoBehaviour
{
    [SerializeField] RenderPipelineAsset[] qualityLevels;
    [SerializeField] TMP_Dropdown dropdown;

    FMOD.Studio.Bus masterbus;

    void Start()
    {
        dropdown.value = QualitySettings.GetQualityLevel();
        masterbus = FMODUnity.RuntimeManager.GetBus("Master Bus");
    }
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        masterbus.setVolume(volume);
        // https://alessandrofama.com/tutorials/fmod-unity/mixer/
        //must do a get in the start so the menu is accurate
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        QualitySettings.renderPipeline = qualityLevels[qualityIndex];
        Debug.Log("Changed");
    }

    public void SetFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
}
