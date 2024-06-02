using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsMenu : Menu
{
    public TMP_Dropdown resDD;

    public Auxiliary aux;

    Resolution[] resolutions;

    private void Awake()
    {
        aux = FindObjectOfType<Auxiliary>();
    }

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

    public void Set2XSpeed()
    {
        if (aux.isFastForward)
        {
            aux.isFastForward = false;
        }
        else
        {
            aux.isFastForward = true;
        }
    }

    public void Set1HP()
    {
        if (aux.is1Health)
        {
            aux.is1Health = false;
        }
        else
        {
            aux.is1Health = true;
        }
    }
}
