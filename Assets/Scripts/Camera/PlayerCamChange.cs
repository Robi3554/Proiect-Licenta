using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamChange : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera virtualCam;
    

    void Start()
    {
        if(virtualCam == null)
        {
            Debug.LogError("Virtual Cam is missing!");
        }

        SetFocus();
    }

    private void SetFocus()
    {
        foreach(Transform player in transform)
        {
            if (player.gameObject.activeSelf)
            {
                virtualCam.Follow = player;
                return;
            }
        }

        Debug.LogWarning("No players found active!");
    }

}
