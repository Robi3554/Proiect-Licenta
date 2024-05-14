using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera firstCamera;
    [SerializeField]
    private CinemachineVirtualCamera secondCamera;

    private CinemachineVirtualCamera currentCamera;

    [SerializeField]
    private float cooldownTime = 5f;

    private bool canSwitch;

    private void Awake()
    {
        currentCamera = firstCamera;

        canSwitch = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && canSwitch)
        {
            if(currentCamera == firstCamera)
            {
                DisableCamera(firstCamera);
                EnableCamera(secondCamera);
                currentCamera = secondCamera;
                StartCoroutine(CanSwitch());
            }
            else if(currentCamera == secondCamera)
            {
                DisableCamera(secondCamera);
                EnableCamera(firstCamera);
                currentCamera = firstCamera;
                StartCoroutine(CanSwitch());
            }
        }
    }

    private void EnableCamera(CinemachineVirtualCamera cam)
    {
        cam.gameObject.SetActive(true);
    }

    private void DisableCamera(CinemachineVirtualCamera cam)
    {
        cam.gameObject.SetActive(false);
    }

    IEnumerator CanSwitch()
    {
        canSwitch = false;

        yield return new WaitForSeconds(cooldownTime);

        canSwitch = true;
    }
}
