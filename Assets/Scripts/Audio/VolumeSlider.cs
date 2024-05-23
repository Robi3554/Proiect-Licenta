using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,
        SFX,
        MUSIC,
        AMBIENCE
    }

    [SerializeField]   
    private VolumeType volumeType;

    private Slider slider;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                slider.value = AudioManager.Instance.masterVolume;
                break;
            case VolumeType.SFX:
                slider.value = AudioManager.Instance.sfxVolume;
                break;
            case VolumeType.MUSIC:
                slider.value = AudioManager.Instance.musicVolume;
                break;
            case VolumeType.AMBIENCE:
                slider.value = AudioManager.Instance.ambienceVolume;
                break;
            default:
                Debug.LogError("Volume Type not suported : " + volumeType);
                break;
        }
    }

    public void OnValueChange()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.Instance.masterVolume = slider.value;
                break;
            case VolumeType.SFX:
                AudioManager.Instance.sfxVolume = slider.value;
                break;
            case VolumeType.MUSIC:
                AudioManager.Instance.musicVolume = slider.value;
                break;
            case VolumeType.AMBIENCE:
                AudioManager.Instance.ambienceVolume = slider.value;
                break;
            default:
                Debug.LogError("Volume Type not suported : " + volumeType);
                break;
        }
    }
}
