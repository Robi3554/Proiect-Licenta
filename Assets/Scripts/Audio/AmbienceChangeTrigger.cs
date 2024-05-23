using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceChangeTrigger : MonoBehaviour
{
    [SerializeField]
    private string parameterName;
    [SerializeField]
    private float parameterValue;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AudioManager.Instance.SetAmbienceParameter(parameterName, parameterValue);
        }
    }
}
