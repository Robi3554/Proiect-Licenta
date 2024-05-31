using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePref : MonoBehaviour
{
    public string volumeKey;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    void Start()
    {
        LoadVolume();
    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey(volumeKey))
        {
            switch (volumeKey)
            {
                case "Master":
                    slider.value = PlayerPrefs.GetFloat(volumeKey);
                    break;
                case "SFX":
                    slider.value = PlayerPrefs.GetFloat(volumeKey);
                    break;
                case "Music":
                    slider.value = PlayerPrefs.GetFloat(volumeKey);
                    break;
                case "Ambience":
                    slider.value = PlayerPrefs.GetFloat(volumeKey);
                    break;
                default:
                    Debug.LogError("Volume Type not suported : " + volumeKey);
                    break;
            }
        }
        else
        {
            slider.value = slider.maxValue;
        }
    }

    public void SaveVolume()
    {
        switch (volumeKey)
        {
            case "Master":
                PlayerPrefs.SetFloat(volumeKey, AudioManager.Instance.masterVolume);
                break;
            case "SFX":
                PlayerPrefs.SetFloat(volumeKey, AudioManager.Instance.sfxVolume);
                break;
            case "Music":
                PlayerPrefs.SetFloat(volumeKey, AudioManager.Instance.musicVolume);
                break;
            case "Ambience":
                PlayerPrefs.SetFloat(volumeKey, AudioManager.Instance.ambienceVolume);
                break;
            default:
                Debug.LogError("Volume Type not suported : " + volumeKey);
                break;
        }
        PlayerPrefs.Save();
    }
}
