using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVC;

    public float timer;
 
    public static CameraShake Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        cinemachineVC = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin channelPerlin = cinemachineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                channelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    public void Shake(float intesity, float time)
    {
        CinemachineBasicMultiChannelPerlin channelPerlin = cinemachineVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        channelPerlin.m_AmplitudeGain = intesity;
        timer = time;
    }
}
