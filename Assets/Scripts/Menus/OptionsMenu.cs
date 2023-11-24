using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer am;

    public TMP_Dropdown resDD;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resDD.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "hz";

            options.Add(option);

            if (resolutions[i].width == Screen.width &&

                resolutions[i].height == Screen.height &&

                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResIndex = i;
            }
        }

        SetUpRes(currentResIndex, options);
    }

    public void SetUpRes(int index, List<string> opt)
    {
        resDD.AddOptions(opt);
        resDD.value = index;
        resDD.RefreshShownValue();
    }

    public void SetVolumeMaster(float volume)
    {
        am.SetFloat("masterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeSFX(float volume)
    {
        am.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeMusic(float volume)
    {
        am.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
