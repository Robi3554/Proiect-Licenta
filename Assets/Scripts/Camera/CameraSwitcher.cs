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
    [SerializeField]
    private Collider2D firstCollider;
    [SerializeField]
    private Collider2D secondCollider;

    private CinemachineVirtualCamera currentCamera;
    private CinemachineConfiner2D confiner;
    private Collider2D currentCollider;


    [SerializeField]
    private float cooldownTime = 5f;

    private bool canSwitch;

    private void Awake()
    {
        currentCamera = firstCamera;

        currentCollider = firstCollider;

        confiner = firstCamera.GetComponent<CinemachineConfiner2D>();

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
                SwitchBoundingShape();
                StartCoroutine(CanSwitch());
            }

            
        }
    }

    public void SwitchBoundingShape()
    {
        if (confiner != null && currentCollider == firstCollider)
        {
            confiner.m_BoundingShape2D = secondCollider;
        }
        else if(confiner != null && currentCollider == secondCollider)
        {
            confiner.m_BoundingShape2D = firstCollider;
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
