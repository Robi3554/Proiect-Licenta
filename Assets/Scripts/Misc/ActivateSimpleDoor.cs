using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSimpleDoor : MonoBehaviour
{
    private SimpleDoor door;

    void Start()
    {
        door = FindObjectOfType<SimpleDoor>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !door.isClosed)
        {
            door.CloseDoor();
        }
    }
}
