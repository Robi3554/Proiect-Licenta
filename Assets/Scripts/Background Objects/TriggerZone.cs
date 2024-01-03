using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private bool oneShot;

    [SerializeField]
    private string collisionTag;

    private bool alreadyEntered;
    private bool alreadyExited;

    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(alreadyEntered) return;

        if (!string.IsNullOrEmpty(collisionTag) && !col.CompareTag(collisionTag)) return;

        onTriggerEnter?.Invoke();

        if(oneShot) alreadyEntered = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(alreadyExited) return;

        if (!string.IsNullOrEmpty(collisionTag) && !col.CompareTag(collisionTag)) return;

        onTriggerExit?.Invoke();

        if(oneShot) alreadyExited = true;
    }
}
