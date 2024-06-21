using Cinemachine;
using System.Collections;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private CinemachineVirtualCamera vc;
    private GameObject player;

    void Start()
    {
        StartCoroutine(StartFollow());
    }

    private IEnumerator StartFollow()
    {
        yield return null;

        vc = GetComponent<CinemachineVirtualCamera>();
        player = GameObject.Find("Player");

        if (vc != null && player != null)
        {
            vc.Follow = player.transform;
        }
    }
}
